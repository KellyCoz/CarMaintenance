using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    class VehicleDisplay
    {
        public static void DisplayPersonal(Personal[] pArray)
        {
            Console.WriteLine("\nList of Personal Vehicles:\n");
            if (pArray.Length > 0)
            {
                int cnt = 0;
                foreach (Personal personal in pArray)
                {
                    cnt++;
                    Console.WriteLine(cnt + ".\t" + personal.year + " " + personal.make + " " + personal.model);
                    personal.OilChange(personal);
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have any personal vehicles\n");
            }
            
        }
        public static void DisplayRental(Rental[] rArray)
        {
            Console.WriteLine("\nList of Rental Vehicles:\n");
            if (rArray.Length > 0)
            {
                int cnt = 0;
                foreach (Rental rental in rArray)
                {
                    cnt++;
                    Console.WriteLine(cnt + ".\t" + rental.year + " " + rental.make + " " + rental.model);
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have any rental vehicles\n");
            }

        }
    }
    
}