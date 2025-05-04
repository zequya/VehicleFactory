using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Enums;
using Vehicle.Tires;

namespace Vehicle.Entities
{
    /// <summary>
    /// Represents a car that inherits from <see cref="AbstractVehicle"/>.
    /// </summary>
    public class Car : AbstractVehicle
    {
        /// <summary>
        /// Gets or sets the tire currently equipped on the car.
        /// </summary>
        public AbstractCarTire CarTire { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with a given vehicle brand.
        /// A default <see cref="SummerTire"/> is assigned to the car.
        /// </summary>
        /// <param name="vehicleBrand">The brand of the car.</param>
        public Car(VehicleBrand vehicleBrand)
                : base(vehicleBrand)
        {
            CarTire = new SummerTire(2.5f, 50.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with a given brand and tire.
        /// </summary>
        /// <param name="vehicleBrand">Brand of the car.</param>
        /// <param name="carTire">Tire assigned to the car.</param>
        public Car(VehicleBrand vehicleBrand, AbstractCarTire carTire)
            : base(vehicleBrand)
        {
            CarTire = carTire;
        }

        public override string ToString()
        {
            return $"Driving a car from {VehicleBrand}.";
        }

        /// <summary>
        /// Changes the tires on a car.
        /// </summary>
        /// <param name="carTire"></param>
        public void ChangeTire(AbstractCarTire carTire)
        {
            CarTire = carTire;
        }

        /// <summary>
        /// Displays detailed information about the car and its tire.
        /// </summary>
        public override void ShowInformation()
        {
            Console.WriteLine(ToString());
            Console.WriteLine(CarTire.ToString());
        }

    }
}
