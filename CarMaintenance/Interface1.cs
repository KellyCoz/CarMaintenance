using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintenance
{
    public interface IVehicle
    {
        IVehicle GetVehicle();
        IVehicle EditVehicle(IVehicle vehicle);
    }
}
