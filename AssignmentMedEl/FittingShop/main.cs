using FittingShop.Simulation;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Tires;

namespace FittingShop
{
    public class main
    {
        public static void Main(string[] args)
        {
            WinterTire winterTire = new(50.0f, -20.0f, 5.0f);
            Car myCar = new(VehicleBrand.Toyota, winterTire);
            //myCar.ShowInformation();

            var cts = new CancellationTokenSource();

            ShopSimulator simulator = new(4, 10);
            simulator.Start();
        }
    }
}
