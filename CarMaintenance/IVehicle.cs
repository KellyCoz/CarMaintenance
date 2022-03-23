using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    public interface IVehicle
    {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        IVehicle GetVehicle();
        //IVehicle EditVehicle(IVehicle vehicle);
        //void DisplayVehicle(IVehicle vehicle);
    }
}
