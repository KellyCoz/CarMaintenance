using System;
using GemBox.Spreadsheet;
using System.Collections.Generic;


namespace CarMaintenance
{
    class Program
    {
        static void Main()
        {
            string userChoice;
            Personal[] pArray = Array.Empty<Personal>();
            Rental[] rArray = Array.Empty<Rental>();
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            
            var personalVehicle = ExcelFile.Load("Files.personalVehicle.csv", new CsvLoadOptions(CsvType.CommaDelimited));

            var pDetails = personalVehicle.Worksheets[0];

            foreach (var row in pDetails.Rows)
            {
               Personal personal = new();
               personal.year = row.Cells[0].StringValue;
               personal.make = row.Cells[1].StringValue;
               personal.model = row.Cells[2].StringValue;
               personal.mileage = row.Cells[3].IntValue;

                Array.Resize(ref pArray, pArray.Length + 1);
                pArray[pArray.Length - 1] = personal;

            }

            
            

            do
            {
                Console.WriteLine("Summary of Vehicles: ");

                vehicleDisplay.displayLists(pArray, rArray);

                Console.WriteLine("Select from numbered list to edit vehicle details.");

                userChoice = Console.ReadLine().ToUpper();

                //Add Regex here

                if(userChoice.Contains("P"))
                {
                    int pSelect = int.Parse(userChoice.Trim('P'));
                    IVehicle pVehicle = pArray[pSelect - 1];
                    pArray[pSelect - 1] = (Personal)pVehicle.EditVehicle(pVehicle);
                }
                else if(userChoice.Contains("R"))
                {
                    int rSelect = int.Parse(userChoice.Trim('R'));
                    IVehicle rVehicle = rArray[rSelect - 1];
                    rArray[rSelect - 1] = (Rental)rVehicle.EditVehicle(rVehicle);
                }
                else if (userChoice == "ADD")
                {
                    //Gather information for a new vehicle
                    Console.Write("Enter 'P' for personal vehicle or 'R' for rental vehicle: ");
                    string userInput = Console.ReadLine().ToUpper();

                    if (userInput == "P")
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
                    else if (userInput == "R")
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
                
            } while (userChoice != "Q");

            
        }
    }
}
