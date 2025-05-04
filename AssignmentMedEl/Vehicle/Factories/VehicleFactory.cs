using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Tires;

namespace Vehicle.Factories
{
    /// <summary>
    /// Provides static methods for creating vehicle instances.
    /// </summary>
    public static class VehicleFactory
    {
        public static Car CreateCar(VehicleBrand vehicleBrand) { return new Car(vehicleBrand); }

        public static Car CreateCarWithTire(VehicleBrand vehicleBrand, AbstractCarTire tire) { return new Car(vehicleBrand, tire); }

        public static Motorcycle CreateMotorcycle(VehicleBrand vehicleBrand) { return new Motorcycle(vehicleBrand); }
    }
}
