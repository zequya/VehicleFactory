using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicles
{
    public class Car : AbstractVehicle
    {

        public AbstractCarTire CarTire { get; set; }

            public Car(VehicleBrand vehicleBrand)
                : base(vehicleBrand)
            {
            CarTire = new SummerTire(2.5f, 50.0f);
            }

            public Car(VehicleBrand vehicleBrand, AbstractCarTire carTire)
                : base(vehicleBrand)
            {
                this.CarTire = carTire;
            }

            public override string ToString()
            {
                return $"Driving a car from {VehicleBrand}.";
            }

            public override void ShowInformation()
            {
                Console.WriteLine(ToString());
                Console.WriteLine(CarTire.ToString());
            }
        
    }
}
