using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    /// <summary>
    /// Contains the main properties every parking spot has: 
    /// ID (e.g. A1), verification whether the spot is occupied or not, 
    /// ID (license plate) of the vehicle occupying the spot, time the spot is reserved until.
    /// </summary>
    internal class ParkingSpot
    {
        private string id;
        private bool isOccupied;
        private string occupiedBy;
        private DateTime? reservedUntil;

        public string Id
        {
            get { return id; }
            set 
            { 
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ID cannot be empty.");
                }

                id = value; 
            }
        }

        public bool IsOccupied
        {
            get { return isOccupied; }
            set { isOccupied = value; }
        }

        public string OccupiedBy
        {
            get { return occupiedBy; }
            set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ID cannot be empty.");
                }

                occupiedBy = value; 
            }
        }

        public DateTime? ReservedUntil
        {
            get { return reservedUntil; }
            set { reservedUntil = value; }
        }

    }
}
