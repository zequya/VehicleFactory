using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;


namespace Vehicle.Entities
{
    public class Motorcycle(VehicleBrand vehicleBrand) : AbstractVehicle(vehicleBrand)
    {
        public override string ToString()
        {
            return $"Driving a motorcycle from {VehicleBrand}.";
        }
    }
}
