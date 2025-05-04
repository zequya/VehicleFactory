using System.Threading;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Factories;
using Vehicle.Tires;



namespace Tests
{
    public class ShowInformationTest
    {
        
        private readonly Mutex _testMutex = new Mutex(false,"TestMutex");

        [Fact]
        public void Test_ShowInformation_Car_DefaultTire()
        {
            _testMutex.WaitOne();

            try
            {
                Car car = VehicleFactory.CreateCar(VehicleBrand.Toyota);
                var expectedOutput =
                    "Driving a car from Toyota." + Environment.NewLine +
                    " And Summer-tires with:" + Environment.NewLine + " Pressure: 2,5" + Environment.NewLine + " MaxTemperature: 50" + Environment.NewLine;

                StringWriter sw = new();
                Console.SetOut(sw);


                car.ShowInformation();
                string output = sw.ToString();


                Assert.Equal(expectedOutput, output);
                
            }
            finally
            {
                _testMutex.ReleaseMutex();
            }
               
        }

        [Fact]
        public void Test_ShowInformation_Motorcycle()
        {
            _testMutex.WaitOne();

            try
            {
                Motorcycle motorcycle = VehicleFactory.CreateMotorcycle(VehicleBrand.KTM);
                var expectedOutput =
                    "Driving a motorcycle from KTM." + Environment.NewLine;

                StringWriter sw = new();
                Console.SetOut(sw);


                motorcycle.ShowInformation();
                string output = sw.ToString();


                Assert.Equal(expectedOutput, output);
                
            }
            finally 
            { 
                _testMutex.ReleaseMutex(); 
            }
            
        }

        [Fact]
        public void Test_ShowInformation_Car_WinterTire()
        {
            _testMutex.WaitOne();

            try
            {
                WinterTire winterTire = new(2.5f, -20.0f, 5.0f);
                Car car = VehicleFactory.CreateCarWithTire(VehicleBrand.Toyota, winterTire);
                var expectedOutput =
                    "Driving a car from Toyota." + Environment.NewLine +
                    " And Winter-tires with:" + Environment.NewLine + " Pressure: 2,5" + Environment.NewLine + " MinTemperature: -20" +
                    Environment.NewLine + " Thickness: 5" + Environment.NewLine;

                StringWriter sw = new();
                Console.SetOut(sw);


                car.ShowInformation();
                string output = sw.ToString();


                Assert.Equal(expectedOutput, output);
                
            }
            finally 
            { 
                _testMutex.ReleaseMutex(); 
            }
            
        }
    }
}