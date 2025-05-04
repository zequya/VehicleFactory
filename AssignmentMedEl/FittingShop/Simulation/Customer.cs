using Vehicle.Entities;

namespace FittingShop.Simulation
{
    /// <summary>
    /// Represents a simulated customer in the tire fitting shop.
    /// Contains a unique ID and a car instance.
    /// </summary>
    public class Customer(int id, Car car)
    {
        public int Id { get; set; } = id;
        public Car Car { get; set; } = car;
    }
}
