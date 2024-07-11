using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    /// <summary>
    /// Creates the parking lot with a list of spots and list of reservations.
    /// </summary>
    internal class ParkingLot
    {
        private List<ParkingSpot> spots = new List<ParkingSpot>();
        private List<ParkingReservation> reservations = new List<ParkingReservation>();

        public List<ParkingSpot> Spots
        {
            get { return spots; }
            set { spots = value; }
        }

        public List<ParkingReservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; }
        }

        public ParkingLot(int numberOfSpots)
        {
            for (int i = 1; i <= numberOfSpots; i++)
            {
                Spots.Add(new ParkingSpot { Id = $"A{i}", IsOccupied = false });
            }
        }

        public void ShowSpots()
        {
            foreach (ParkingSpot spot in Spots)
            {
                Console.WriteLine($"Spot: {spot.Id}, " +
                    $"Occupied: {(spot.IsOccupied ? "Yes" : "No")}, " +
                    $"Occupied By: {(spot.OccupiedBy == null ? "No one" : spot.OccupiedBy)}, " +
                    $"Reserved Until: {spot.ReservedUntil}");
            }
        }

        public void BookSpot(string spotId, string vehicleNumber, DateTime startTime, DateTime endTime, string type)
        {
            ParkingSpot spot = Spots.FirstOrDefault(s => s.Id == spotId);
            if (spot.IsOccupied)
            {
                Console.WriteLine("Spot is already occupied.");
                return;
            }

            spot.IsOccupied = true;
            spot.OccupiedBy = vehicleNumber;
            spot.ReservedUntil = endTime;

            ParkingReservation reservation = new ParkingReservation()
            {
                Spot = spot,
                VehicleNumber = vehicleNumber,
                StartTime = startTime,
                EndTime = endTime,
                Type = type
            };
            reservation.Validation();
            reservations.Add(reservation);

            Console.WriteLine($"Spot {spotId} was booked successfully for vehicle {vehicleNumber}. Cost: {CalculateCost(startTime, endTime, type):F2}");
        }

        public void ReleaseSpot(string spotId, string vehicleNumber)
        {
            ParkingReservation reservation = Reservations.FirstOrDefault(r => r.Spot.Id == spotId && r.VehicleNumber == vehicleNumber);
            if (reservation == null)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            if (reservation.Type != "Subscription")
            {
                TimeSpan remainingTime = reservation.EndTime - DateTime.Now;
                double refund = remainingTime.TotalHours * 0.70;
                Console.WriteLine($"Releasing spot {spotId}. Refund amount: {refund:F2}.");
            }

            reservation.Spot.IsOccupied = false;
            reservation.Spot.OccupiedBy = "No one";
            reservation.Spot.ReservedUntil = null;

            Reservations.Remove(reservation);
        }

        public static double CalculateCost(DateTime startTime, DateTime endTime, string type)
        {
            double cost = 0;
            switch (type)
            {
                case "OnDemand":
                    cost = (endTime - startTime).TotalHours;
                    break;
                case "Advance":
                    int daysInAdvance = (startTime - DateTime.Now).Days;
                    cost = (endTime - startTime).TotalHours * (daysInAdvance >= 2 ? 1.20 : 1.00);
                    break;
                case "Subscription":
                    cost = 168;
                    break;
            }

            return cost;
        }

        public List<ParkingReservation> GetReservations(DateTime? startDate, DateTime? endDate)
        {
            var query = Reservations.AsQueryable();

            if (startDate.HasValue)
            {
                query = query.Where(r => r.StartTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(r => r.EndTime <= endDate.Value);
            }

            return query.ToList();
        }

        public double GetEarnings(DateTime? startDate, DateTime? endDate)
        {
            var reservations = GetReservations(startDate, endDate);
            return reservations.Sum(r => ParkingLot.CalculateCost(r.StartTime, r.EndTime, r.Type));
        }
    }
}
