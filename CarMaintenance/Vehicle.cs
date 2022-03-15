using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    public class Vehicle
    {
        public string year;
        public string make;
        public string model;
        public int mileage;
        public string vehicleSummary;

        public int addMileage(int mileage)
        {
            mileage += mileage;
            return mileage;
        }
    }
}