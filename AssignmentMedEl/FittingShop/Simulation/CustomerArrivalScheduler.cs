using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FittingShop.Logging;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Factories;



namespace FittingShop.Simulation
{
    public class CustomerArrivalScheduler(int totalCustomers, BlockingCollection<Customer> queue, Logger logger)
    {
        private readonly int _totalCustomers = totalCustomers;
        private readonly BlockingCollection<Customer> _queue = queue;
        private readonly Random _random = new();
        private readonly Logger _logger = logger;

        public void Start()
        {
            for (int i = 1; i <= _totalCustomers; i++)
            {
                long delay = (long)(_random.NextDouble() * 1000);

                VehicleBrand brand = i % 2 == 0 ? VehicleBrand.Honda : VehicleBrand.Toyota;
                Car car = VehicleFactory.CreateCar(brand);
                Customer customer = new(i, car);

                _logger.Log($"Customer {customer.Id} has arrived. {customer.Car}\n{customer.Car.CarTire}");

                try
                {
                    _queue.Add(customer);
                }
                catch (InvalidOperationException)
                {
                    // Happens if the collection is marked as completed.
                    Thread.CurrentThread.Interrupt();
                }

                try
                {
                    Thread.Sleep((int)delay);
                }
                catch (ThreadInterruptedException)
                {
                    Console.Error.WriteLine("Sleep interrupted");
                }
            }
        }
    }
}
