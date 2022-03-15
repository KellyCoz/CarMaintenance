using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    class vehicleDisplay
    {
        public static void displayLists(Personal[] pArray, Rental[] rArray)
        {
            Console.WriteLine("\nList of Personal Vehicles:\n");
            if (pArray.Length > 0)
            {
                int cnt = 0;
                foreach (Personal personal in pArray)
                {
                    cnt++;
                    Console.WriteLine("P"+cnt + ".\t" + personal.year + " " + personal.make + " " + personal.model);
                    personal.OilChange(personal.mileage, personal.mileageOfLastOilChange, personal.lastOilChangeDate);
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have any personal vehicles\n");
            }
            Console.WriteLine("\nList of Rental Vehicles:\n");
            if (rArray.Length > 0)
            {
                int cnt = 0;
                foreach (Rental rental in rArray)
                {
                    cnt++;
                    Console.WriteLine("R"+cnt + ". " + rental.year + " " + rental.make + " " + rental.model);
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have any rental vehicles");
            }

        }
    }
}