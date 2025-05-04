using Vehicle.Enums;
using Vehicle.Interfaces;



namespace Vehicle.Entities
{
    /// <summary>
    /// Represents an abstract base class for vehicles.
    /// Implements <see cref="IVehicle"/> and stores the vehicle brand.
    /// </summary>
    /// <param name="vehicleBrand">Brand of the vehicle.</param>
    public abstract class AbstractVehicle(VehicleBrand vehicleBrand) : IVehicle
    {
        protected VehicleBrand VehicleBrand = vehicleBrand;

        public virtual void ShowInformation()
        {
            Console.WriteLine(ToString());
        }
    }
}
