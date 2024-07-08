using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new ParkingLot(5);
            string cont = "yes";

            while (cont != "no")
            {
                Console.WriteLine("Initial Parking Spots:");
                parkingLot.ShowSpots();

                Console.WriteLine();

                Console.WriteLine("Enter role (User/Admin):");
                string role = Console.ReadLine();

                if (role.Equals("User", StringComparison.OrdinalIgnoreCase))
                {
                    Actions.HandleUserActions(parkingLot);
                }
                else if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    Actions.HandleAdminActions(parkingLot);
                }
                else
                {
                    Console.WriteLine("Invalid role. Please enter either User or Admin.");
                }

                Console.Write("Do you want to continue? - ");
                cont = Console.ReadLine();
                Console.WriteLine();

                //    string[] input = Console.ReadLine().Split();
                //    if (input[0] == "book")
                //    {
                //        string spotName = input[1];
                //        string licensePlate = input[2];

                //        int[] startDate = input[3].Split("-").Select(int.Parse).ToArray();
                //        DateTime startingDate = new DateTime(startDate[0], startDate[2], startDate[1]);

                //        int[] endDate = input[4].Split("-").Select(int.Parse).ToArray();
                //        DateTime endingDate = new DateTime(endDate[0], endDate[2], endDate[1]);

                //        string typeRez = input[5];

                //        parkingLot.BookSpot(spotName,
                //            licensePlate, startingDate, endingDate, typeRez);
                //    }
                //    else if (input[0] == "release")
                //    {
                //        string spotName = input[1];
                //        string licensePlate = input[2];

                //        Console.WriteLine("\nReleasing a spot:");
                //        parkingLot.ReleaseSpot(spotName, licensePlate);
                //    }

                //    Console.WriteLine("\nCurrent Parking Spots:");
                //    parkingLot.ShowSpots();

                //    Console.WriteLine();
                //    Console.Write("Continue? - ");
                //    cont = Console.ReadLine();
                //}

                //Console.WriteLine("\nFinal Parking Spots:");
                //parkingLot.ShowSpots();
            }

            Console.WriteLine("\nFinal Parking Spots:");
            parkingLot.ShowSpots();
        }
    }
}
