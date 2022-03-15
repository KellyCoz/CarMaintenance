using System;
using System.IO;
using GemBox.Spreadsheet;
using System.Collections.Generic;


namespace CarMaintenance
{
    class Program
    {
        static void Main()
        {
            string userChoice1="";
            string userChoice2="";
            Personal[] pArray = Array.Empty<Personal>();
            Rental[] rArray = Array.Empty<Rental>();

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var pReader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv");
            var rReader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv");

            if (Directory.Exists($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv"))
            {
                //Read the personal csv into the personal array
                while (!pReader.EndOfStream)
                {
                    var lineFromPReader = pReader.ReadLine();
                    String[] pReaderArray = lineFromPReader.Split(',');
                    Personal personal = new();
                    personal.year = pReaderArray[0];
                    personal.make = pReaderArray[1];
                    personal.model = pReaderArray[2];
                    personal.mileage = int.Parse(pReaderArray[3]);
                    personal.mileageOfLastOilChange = int.Parse(pReaderArray[4]);
                    personal.lastOilChangeDate = DateTime.Parse(pReaderArray[5]);

                    Array.Resize(ref pArray, pArray.Length + 1);
                    pArray[pArray.Length - 1] = personal;

                }
            }
            //Read the rental csv into the rental array
            if (Directory.Exists($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv"))
            {
                while (!rReader.EndOfStream)
                {
                    var lineFromRReader = rReader.ReadLine();
                    String[] rReaderArray = lineFromRReader.Split(',');
                    Rental rental = new();
                    rental.year = rReaderArray[0];
                    rental.make = rReaderArray[1];
                    rental.model = rReaderArray[2];
                    rental.mileage = int.Parse(rReaderArray[3]);
                    rental.rentalDate = DateTime.Parse(rReaderArray[4]);
                    rental.rentalPeriod = int.Parse(rReaderArray[5]);

                    Array.Resize(ref rArray, rArray.Length + 1);
                    rArray[rArray.Length - 1] = rental;

                }
            }
            //Run the program
            do
            {
                Console.WriteLine("Summary of Vehicles: ");

                VehicleDisplay.DisplayPersonal(pArray);
                VehicleDisplay.DisplayRental(rArray);

                Console.WriteLine("\nWould you like to [A]dd a vehicle, [E]dit a vehicle, or [Q]uit the application?");

                userChoice1 = Console.ReadLine().ToUpper();
                if(userChoice1!="Q")
                {
                    Console.Write("\nSelect [P]ersonal or [R]ental: ");
                    userChoice2 = Console.ReadLine();
                }
                //Add Regex here
                if (userChoice1 == "E")
                {
                    if (userChoice2=="P")
                    {
                        VehicleDisplay.DisplayPersonal(pArray);
                        Console.Write("\nSelect Vehicle from numbered list.");
                        int pSelect = int.Parse(Console.ReadLine());
                        IVehicle pVehicle = pArray[pSelect - 1];
                        pArray[pSelect - 1] = (Personal)pVehicle.EditVehicle(pVehicle);
                    }
                    else if (userChoice2=="R")
                    {
                        VehicleDisplay.DisplayRental(rArray);
                        Console.Write("\nSelect Vehicle from numbered list.");
                        int rSelect = int.Parse(Console.ReadLine());
                        IVehicle rVehicle = rArray[rSelect - 1];
                        rArray[rSelect - 1] = (Rental)rVehicle.EditVehicle(rVehicle);
                    }
                }
                else if (userChoice1 == "A")
                {

                    if (userChoice2 == "P")
                    {
                        Personal personal = new();
                        IVehicle vehicle = personal.GetVehicle();
                        personal = (Personal)vehicle;
                        Array.Resize(ref pArray, pArray.Length + 1);
                        pArray[pArray.Length - 1] = personal;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your " + personal.year + " " + personal.make + " " + personal.model + " has been added to the database.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (userChoice2 == "R")
                    {
                        Rental rental = new();
                        IVehicle vehicle = rental.GetVehicle();
                        rental = (Rental)vehicle;
                        Array.Resize(ref rArray, rArray.Length + 1);
                        rArray[rArray.Length - 1] = rental;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your " + rental.year + " " + rental.make + " " + rental.model + " has been added to the database.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.WriteLine("You have entered an invalid choice. Please make selection as either P1 (P2, P3..) or R1 (R2, R3...)");
                }
                
            } while (userChoice1 != "Q");
            
            //close the readers
            pReader.Close();
            rReader.Close();

            //Delete Old files replace with new blank file
            if (!Directory.Exists($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv"))
            {
                Directory.CreateDirectory($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv");
            }
            else if(Directory.Exists($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv"))
            {
                Directory.Delete($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv");
                Directory.CreateDirectory($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv");
            }
            if (!Directory.Exists($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv"))
            {
                Directory.CreateDirectory($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv");
            }
            else if (Directory.Exists($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv"))
            {
                Directory.Delete($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv");
                Directory.CreateDirectory($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv");
            }
            //write arrays to the new, blank file
            
            //close the writers

        }
    }
}
