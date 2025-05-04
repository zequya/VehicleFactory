using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;


namespace Vehicle.Entities
{
    /// <summary>
    /// Represents a motorcycle, derived from <see cref="AbstractVehicle"/>.
    /// </summary>
    /// <param name="vehicleBrand">Brand of the motorcycle.</param>
    public class Motorcycle(VehicleBrand vehicleBrand) : AbstractVehicle(vehicleBrand)
    {
        public override string ToString()
        {
            return $"Driving a motorcycle from {VehicleBrand}.";
        }
    }
}
