using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FittingShop.Simulation;
using Vehicles;



namespace FittingShop
{
    public class main
    {
        public static void Main(string[] args)
        {
            WinterTire winterTire = new(50.0f, -20.0f, 5.0f);
            Car myCar = new(VehicleBrand.Toyota,winterTire);
            myCar.ShowInformation();
            

            //ShopSimulator simulator = new(4, 10);
            //simulator.Start();
        }
    }
}
