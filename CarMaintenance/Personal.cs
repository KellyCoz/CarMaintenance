using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    class Personal: IVehicle
    {
        public int mileageOfLastOilChange;
        public DateTime lastOilChangeDate;
        public string year;
        public string Year
        {
            get => year;
            set => year = value;
        }
        public string make;
        public string Make
        {
            get => make;
            set => make = value;
        }
        public string model;
        public string Model
        {
            get => model;
            set => model = value;
        }
        public int mileage;
        public int Mileage
        {
            get => mileage;
            set => mileage = value;
        }
        public IVehicle GetVehicle()
        {
            Console.WriteLine("\nFirst let's get some information about your vehicle.");
            Console.Write("Please enter the year: ");
            year = Console.ReadLine();
            Console.WriteLine("\nPlease enter the make: ");
            make = Console.ReadLine();
            Console.Write("\nPlease enter the model: ");
            model = Console.ReadLine();
            Console.Write("\nPlease enter current mileage: ");
            mileage = int.Parse(Console.ReadLine());
            Console.Write("\nPlease enter mileage of at last oil change:");
            mileageOfLastOilChange = int.Parse(Console.ReadLine());
            Console.Write("\nPlease enter date of at last oil change (mm-dd-yyy): ");
            lastOilChangeDate = DateTime.Parse(Console.ReadLine());

            Personal personal = new()
            { year = year, 
                make=make, 
                model=model,
                mileage=mileage, 
                mileageOfLastOilChange=mileageOfLastOilChange, 
                lastOilChangeDate=lastOilChangeDate };
           
            
            return personal;

        }
        public void DisplayVehicle(Personal personal)
        {
            Console.WriteLine("Vehicle details: ");
            Console.WriteLine("[Y]ear: " + personal.Year);
            Console.WriteLine("[Ma]ke: " + personal.Make);
            Console.WriteLine("[Mo]del: " + personal.Model);
            Console.WriteLine("[Mi]leage: " + personal.Year);
            Console.WriteLine("[D]ate of Oil Change: " + personal.lastOilChangeDate);

        }
        public Personal EditVehicle(Personal personal)
        {
            string choice = "";

            DisplayVehicle(personal);

            do
            {
                string updatedValue;

                Console.WriteLine("Select a detail to edit. (Type [S] to save.)");
                choice = Console.ReadLine().ToUpper();
                Console.Write("Enter the new value: ");
                updatedValue = Console.ReadLine();

                if (choice == "Y")
                    personal.year = updatedValue;
                else if (choice == "MA")
                    personal.make = updatedValue;
                else if (choice == "MO")
                    personal.model = updatedValue;
                else if (choice == "MI")
                    personal.mileage = int.Parse(updatedValue);
                else if (choice == "D")
                    personal.lastOilChangeDate = DateTime.Parse(updatedValue);

            } while (choice != "S");
            return personal;
         }

        public void OilChange(int mileage, int mileageOfLastOilChange, DateTime lastOilChangeDate)
        {
            int milesUntilOilChange = 3000 - (mileage - mileageOfLastOilChange);
            int daysUntilOilChange = 90 - (int)(DateTime.Now - lastOilChangeDate).TotalDays;
            if (daysUntilOilChange <= 0 || milesUntilOilChange <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\tYour "+year+" "+make+" "+model+" is overdue for an oil change!");
                if(daysUntilOilChange <=0)
                {
                    Console.WriteLine("\tVehicle was do for oil change " + (0 - daysUntilOilChange) + " days ago.");
                }
                if(milesUntilOilChange<=0)
                {
                    Console.WriteLine("\tVehicle was due for oil change " + (0 - milesUntilOilChange) + " miles ago.");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if ((0 < milesUntilOilChange && milesUntilOilChange <= 500) || (daysUntilOilChange > 0 && daysUntilOilChange <= 15))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\tConsider scheduling an oil change in the next " + milesUntilOilChange + " miles or in the next " + daysUntilOilChange + " days.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\tVehicle does not need an oil change.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
