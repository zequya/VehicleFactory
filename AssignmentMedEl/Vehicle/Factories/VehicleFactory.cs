using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Tires;

namespace Vehicle.Factories
{
    public static class VehicleFactory
    {
        public static Car CreateCar(VehicleBrand vehicleBrand) {  return new Car(vehicleBrand); }

        public static Car CreateCarWithTire(VehicleBrand vehicleBrand, AbstractCarTire tire) { return new Car(vehicleBrand, tire); }

        public static Motorcycle CreateMotorcycle(VehicleBrand vehicleBrand) {return new Motorcycle(vehicleBrand); }
    }
}
