using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class Actions
    {
        public static void HandleUserActions(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter vehicle number:");
            string vehicleNumber = Console.ReadLine();

            Console.WriteLine("Choose action: (1) Book Spot (2) Release Spot");
            string action = Console.ReadLine();

            if (action == "1")
            {
                BookSpotInterface(parkingLot, vehicleNumber);
            }
            else if (action == "2")
            {
                ReleaseSpotInterface(parkingLot, vehicleNumber);
            }
            else
            {
                Console.WriteLine("Invalid action. Please choose either 1 or 2.");
            }
        }

        public static void HandleAdminActions(ParkingLot parkingLot)
        {
            Console.WriteLine("Choose action: (1) View Reservations (2) View Earnings");
            string action = Console.ReadLine();

            if (action == "1")
            {
                ViewReservations(parkingLot);
            }
            else if (action == "2")
            {
                ViewEarnings(parkingLot);
            }
            else
            {
                Console.WriteLine("Invalid action. Please choose either 1 or 2.");
            }
        }

        public static void BookSpotInterface(ParkingLot parkingLot, string vehicleNumber)
        {
            Console.WriteLine("Enter type (OnDemand/Advance/Subscription):");
            string type = Console.ReadLine();

            string spotId;
            DateTime startTime;
            DateTime endTime;

            if (type == "OnDemand")
            {
                Console.WriteLine($"Enter spot ID (from A1 to A{parkingLot.Spots.Count}):");
                spotId = Console.ReadLine();

                startTime = DateTime.Now.AddMinutes(10);
                endTime = DateTime.Now.AddHours(24);
            }
            else if (type == "Subscription")
            {
                Console.WriteLine($"Enter spot ID (from A1 to A{parkingLot.Spots.Count}):");
                spotId = Console.ReadLine();

                startTime = DateTime.Now.AddMinutes(10);
                endTime = DateTime.Now.AddDays(30);
            }
            else
            {
                Console.WriteLine($"Enter spot ID (from A1 to A{parkingLot.Spots.Count}):");
                spotId = Console.ReadLine();

                Console.WriteLine("Enter start time (yyyy-mm-dd hh:mm):");
                startTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter end time (yyyy-mm-dd hh:mm):");
                endTime = DateTime.Parse(Console.ReadLine());
            }

            parkingLot.BookSpot(spotId, vehicleNumber, startTime, endTime, type);
        }

        public static void ReleaseSpotInterface(ParkingLot parkingLot, string vehicleNumber)
        {
            Console.WriteLine("Enter spot ID:");
            string spotId = Console.ReadLine();

            parkingLot.ReleaseSpot(spotId, vehicleNumber);
        }

        public static void ViewReservations(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter start date (yyyy-mm-dd) or press Enter for no start date:");
            string startDateInput = Console.ReadLine();
            DateTime? startDate = string.IsNullOrEmpty(startDateInput) ? (DateTime?)null : DateTime.Parse(startDateInput);

            Console.WriteLine("Enter end date (yyyy-mm-dd) or press Enter for no end date:");
            string endDateInput = Console.ReadLine();
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);

            var reservations = parkingLot.GetReservations(startDate, endDate);

            Console.WriteLine("Reservations:");
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Spot: {reservation.Spot.Id}, " +
                    $"Vehicle: {reservation.VehicleNumber}, " +
                    $"Start: {reservation.StartTime}, " +
                    $"End: {reservation.EndTime}, " +
                    $"Cost: {ParkingLot.CalculateCost(reservation.StartTime, reservation.EndTime, reservation.Type):F2}");
            }
        }

        public static void ViewEarnings(ParkingLot parkingService)
        {
            Console.WriteLine("Enter start date (yyyy-mm-dd) or press Enter for no start date:");
            string startDateInput = Console.ReadLine();
            DateTime? startDate = string.IsNullOrEmpty(startDateInput) ? (DateTime?)null : DateTime.Parse(startDateInput);

            Console.WriteLine("Enter end date (yyyy-mm-dd) or press Enter for no end date:");
            string endDateInput = Console.ReadLine();
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);

            double earnings = parkingService.GetEarnings(startDate, endDate);
            Console.WriteLine($"Total earnings: {earnings:F2}");
        }
    }
}
