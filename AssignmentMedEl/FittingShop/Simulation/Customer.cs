using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Entities;


namespace FittingShop.Simulation
{
    public class Customer(int id, Car car)
    {
        public int Id { get; set; } = id;
        public Car Car { get; set; } = car;
    }
}
