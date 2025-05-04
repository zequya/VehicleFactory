using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;
using Vehicle.Interfaces;



namespace Vehicle.Entities
{
    public abstract class AbstractVehicle(VehicleBrand vehicleBrand) : IVehicle
    {
        protected VehicleBrand VehicleBrand = vehicleBrand;

        public virtual void ShowInformation()
        { 
            Console.WriteLine(ToString()); 
        }
    }
}
