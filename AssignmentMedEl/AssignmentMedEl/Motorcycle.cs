using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Motorcycle(VehicleBrand vehicleBrand) : AbstractVehicle(vehicleBrand)
    {
        public override string ToString()
        {
            return $"Driving a motorcycle from {VehicleBrand}.";
        }
    }
}
