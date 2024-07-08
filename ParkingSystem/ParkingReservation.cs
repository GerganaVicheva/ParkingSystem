using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    /// <summary>
    /// Contains the main properties every reservation has: 
    /// reserved spot, ID (license plate) of the vehicle using the spot, 
    /// time period of using the spot, type of reservation.
    /// </summary>
    internal class ParkingReservation
    {
        private ParkingSpot spot;
        private string vehicleNumber;
        private DateTime startTime;
        private DateTime endTime;
        private string type; // OnDemand, Advance, Subscription

        public ParkingSpot Spot
        {
            get { return spot; }
            set { spot = value; }
        }

        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vehicle number cannot be empty.");
                }

                vehicleNumber = value;
            }
        }
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if (DateTime.Compare(value, DateTime.Now) == -1)
                {
                    throw new ArgumentException("The start date cannot be set before the current day.");
                }

                startTime = value;
            }
        }
        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                if (DateTime.Compare(value, StartTime) == -1)
                {
                    throw new ArgumentException("The end date cannot be set before the start day.");
                }

                endTime = value;
            }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        //public double CostRes 
        //{ 
        //    get { return costRes; }
        //    set { value  = costRes; }
        //}

        //public ParkingReservation()
        //{
        //    if (Type == "OnDemand" && ((StartTime.DayOfWeek.Equals(6) || StartTime.DayOfWeek.Equals(0))))
        //    {
        //        if (!(EndTime.DayOfWeek.Equals(6) || EndTime.DayOfWeek.Equals(0)))
        //        {
        //            throw new ArgumentException("The end date cannot be later than Sunday.");
        //        }
        //    }
        //    else if (Type == "OnDemand" && !(StartTime.DayOfWeek.Equals(6) || StartTime.DayOfWeek.Equals(0)))
        //    {
        //        if (EndTime.Subtract(StartTime).TotalMinutes < 60 || EndTime.Subtract(StartTime).TotalHours > 24)
        //        {
        //            throw new ArgumentException("Your reservation cannot be less than 1 hour and more than 1 day.");
        //        }
        //    }
        //    else if (Type == "Advance")
        //    {
        //        if (DateTime.Now.Subtract(StartTime).TotalDays < 7)
        //        {
        //            throw new ArgumentException("To book in advance there has to be a week before the reservation.");
        //        }

        //        if (EndTime.Subtract(StartTime).TotalDays < 1 || EndTime.Subtract(StartTime).TotalDays > 7)
        //        {
        //            throw new ArgumentException("Your reservation cannot be less than 1 day and more than 1 week.");
        //        }
        //    }
        //}

        public void Validation()
        {
            if (Type == "OnDemand" && ((StartTime.DayOfWeek.Equals(6) || StartTime.DayOfWeek.Equals(0))))
            {
                if (!(EndTime.DayOfWeek.Equals(6) || EndTime.DayOfWeek.Equals(0)))
                {
                    throw new ArgumentException("The end date cannot be later than Sunday.");
                }
            }
            else if (Type == "OnDemand" && !(StartTime.DayOfWeek.Equals(6) || StartTime.DayOfWeek.Equals(0)))
            {
                if (EndTime.Subtract(StartTime).TotalMinutes < 60 || EndTime.Subtract(StartTime).TotalHours > 24)
                {
                    throw new ArgumentException("Your reservation cannot be less than 1 hour and more than 1 day.");
                }
            }
            else if (Type == "Advance")
            {
                if (DateTime.Now.Subtract(StartTime).TotalDays < 7)
                {
                    throw new ArgumentException("To book in advance there has to be a week before the reservation.");
                }

                if (EndTime.Subtract(StartTime).TotalDays < 1 || EndTime.Subtract(StartTime).TotalDays > 7)
                {
                    throw new ArgumentException("Your reservation cannot be less than 1 day and more than 1 week.");
                }
            }
        }
    }
}
