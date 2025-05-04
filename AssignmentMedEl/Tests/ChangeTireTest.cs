using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Factories;
using Vehicle.Tires;

namespace Tests
{
    public class ChangeTireTest
    {
        /// <summary>
        /// Tests the tire change functionality of a car
        /// </summary>
        [Fact]
        public void Test_Tire_Change()
        {
            WinterTire winterTire = new(2.5f, -20.0f, 5.0f);
            Car car = VehicleFactory.CreateCar(VehicleBrand.Honda);

            car.ChangeTire(winterTire);

            AbstractCarTire testTire = car.CarTire;

            Assert.Equal(winterTire, testTire);
        }
    }
}
