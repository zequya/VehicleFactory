

using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Factories;

namespace Tests
{
    public class ShowInformationTest
    {
        [Fact]
        public void Test_ShowInformatio_Car()
        {
            Car car = VehicleFactory.CreateCar(VehicleBrand.Toyota);

            StringWriter sw = new();
            Console.SetOut(sw);

            car.ShowInformation();
            
            string output = sw.ToString().Trim();
            
            sw.Close();
            Assert.Contains("Driving a car from Toyota.", output);
            Assert.Contains("Pressure: 2.5", output); 
            Assert.Contains("MaxTemperature: 50", output);



        }
    }
}