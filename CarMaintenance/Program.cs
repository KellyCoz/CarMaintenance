using System;
using System.IO;
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

            //var pReader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}personalVehicle.csv");
            //var rReader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}rentalVehicle.csv");

            var pReader = new StreamReader("personalVehicle.csv");
            var rReader = new StreamReader("rentalVehicle.csv");

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
            //Read the rental csv into the rental array

                while (!rReader.EndOfStream)
                {
                    var lineFromRReader = rReader.ReadLine();
                    String[] rReaderArray = lineFromRReader.Split(',');
                    Rental rental = new();
                    rental.year = rReaderArray[0];
                    rental.make = rReaderArray[1];
                    rental.model = rReaderArray[2];
                    rental.mileage = int.Parse(rReaderArray[3]);
                    rental.mileageWhenRented=int.Parse(rReaderArray[4]);
                    rental.rentalDate = DateTime.Parse(rReaderArray[5]);
                    rental.rentalPeriod = int.Parse(rReaderArray[6]);

                    Array.Resize(ref rArray, rArray.Length + 1);
                    rArray[rArray.Length - 1] = rental;

                }
            //Run the program
            do
            {
                Console.WriteLine("Summary of Vehicles: ");

                VehicleDisplay.DisplayPersonal(pArray);
                VehicleDisplay.DisplayRental(rArray);

                Console.WriteLine("\nWould you like to [A]dd a vehicle, [E]dit a vehicle, [D]elete a vehicle, or [Q]uit the application?");

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
                else if(userChoice1=="D")
                {
                    if(userChoice2=="P")
                    {
                        VehicleDisplay.DisplayPersonal(pArray);
                        Console.WriteLine("Please select the number corresponding to the vehicle you want to delete");

                        int position = int.Parse(Console.ReadLine())-1;
                        //delete 2nd item out of 3 -> position = 1, Length = 3
                        while(position<pArray.Length)
                        {
                            
                            if(position ==pArray.Length-1)
                            {
                                Array.Resize(ref pArray, pArray.Length - 1);
                            }
                            else
                            {
                                pArray[position] = pArray[position + 1];
                                position++;
                            }
                        }

                    }
                    else if(userChoice2=="R")
                    {
                        VehicleDisplay.DisplayRental(rArray);
                        Console.WriteLine("Please select the number corresponding to the vehicle you want to delete");

                        int position = int.Parse(Console.ReadLine())-1;

                        while (position < rArray.Length)
                        {

                            if (position == rArray.Length - 1)
                            {
                                Array.Resize(ref rArray, rArray.Length - 1);
                            }
                            else
                            {
                                rArray[position] = rArray[position + 1];
                                position++;
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Please select the number corresponding to the Vehicle you wish to select.");
                }
                
            } while (userChoice1 != "Q");
            
            //close the readers
            pReader.Close();
            rReader.Close();

            //declare streamwriters, with append=false (so that it will overwrite the old file)
          
            var pWriter = new StreamWriter("personalVehicle.csv",false);
            var rWriter = new StreamWriter("rentalVehicle.csv",false);
            //write arrays to the new, blank file
            foreach (Personal personal in pArray)
            {
                pWriter.WriteLine(personal.year+","+personal.make+","+personal.model+","+personal.mileage.ToString()+","+personal.mileageOfLastOilChange+","+personal.lastOilChangeDate.ToString());
            }
            foreach(Rental rental in rArray)
            {
                rWriter.WriteLine(rental.year+","+rental.make+","+rental.model+","+rental.mileage.ToString()+","+rental.mileageWhenRented.ToString()+","+rental.rentalDate.ToString()+","+rental.rentalPeriod.ToString());
            }
            //close the writers
            pWriter.Close();
            rWriter.Close();
        }
    }
}
