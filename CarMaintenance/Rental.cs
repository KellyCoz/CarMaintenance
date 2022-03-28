using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    class Rental: IVehicle
    {
        public int mileageWhenRented;
        public DateTime rentalDate;
        public int rentalPeriod;
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
        //public List<IVehicle> rentals = new List<IVehicle>();

        public IVehicle GetVehicle()
        {
            Console.WriteLine("\nFirst let's get some information about your vehicle.");
            Console.Write("Please enter the year: ");
            year = Console.ReadLine();
            Console.Write("\nPlease enter the make: ");
            make = Console.ReadLine();
            Console.Write("\nPlease enter the model: ");
            model = Console.ReadLine();
            Console.Write("\nPlease enter current mileage: ");
            mileage = int.Parse(Console.ReadLine());
            Console.Write("\nPlease enter mileage at time of rental:");
            mileageWhenRented = int.Parse(Console.ReadLine());
            Console.Write("\nPlease enter the rental date (mm-dd-yyy): ");
            rentalDate = DateTime.Parse(Console.ReadLine());
            Console.Write("\nEnter the number of days the car is to be rented");
            rentalPeriod = int.Parse(Console.ReadLine());

            Rental rental = new()
            {
                year = year,
                make = make,
                model = model,
                mileage = mileage,
                rentalDate = rentalDate,
                rentalPeriod = rentalPeriod
            };
            
            return rental;
        }
  
        public void DisplayVehicle(Rental rental)
        {
            Console.WriteLine("Vehicle details: ");
            Console.WriteLine("[Y]ear: " + rental.Year);
            Console.WriteLine("[Ma]ke: " + rental.Make);
            Console.WriteLine("[Mo]del: " + rental.Model);
            Console.WriteLine("[Mi]leage: " + rental.Year);
            Console.WriteLine("[B]eginning Mileage: " + rental.mileageWhenRented);
            Console.WriteLine("[D]ate rental began: " + rental.rentalDate);

        }

        public Rental EditVehicle(Rental rental)
        {
            string choice;

            DisplayVehicle(rental);

            do
            {
                string updatedValue;

                Console.WriteLine("Select a detail to edit. (Type [S] to save.)");
                choice = Console.ReadLine().ToUpper();

                if (choice != "S")
                {
                    Console.Write("Enter the new value: ");
                    updatedValue = Console.ReadLine();

                    if (choice == "Y")
                        rental.year = updatedValue;
                    else if (choice == "MA")
                        rental.make = updatedValue;
                    else if (choice == "MO")
                        rental.model = updatedValue;
                    else if (choice == "MI")
                        rental.mileage = int.Parse(updatedValue);
                    else if (choice == "B")
                        rental.mileageWhenRented = int.Parse(updatedValue);
                    else if (choice == "D")
                        rental.rentalDate = DateTime.Parse(updatedValue);
                }

            } while (choice != "S");
            return rental;
        }

    }
}
