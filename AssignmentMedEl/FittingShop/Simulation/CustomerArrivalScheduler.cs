using System.Collections.Concurrent;
using FittingShop.Logging;
using Vehicle.Entities;
using Vehicle.Enums;
using Vehicle.Factories;

namespace FittingShop.Simulation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerArrivalScheduler"/> class.
    /// Creates customers and schedules their arrival in the queue.
    /// </summary>
    /// <param name="totalCustomers">Total number of customers to be served.</param>
    /// <param name="queue">Queue where customers are placed for processing.</param>
    /// <param name="logger">Logger used to print execution details.</param>
    public class CustomerArrivalScheduler(int totalCustomers, BlockingCollection<Customer> queue, Logger logger)
    {
        private readonly int _totalCustomers = totalCustomers;
        private readonly BlockingCollection<Customer> _queue = queue;
        private readonly Random _random = new();
        private readonly Logger _logger = logger;

        /// <summary>
        /// Starts the simulation of customer arrivals.
        /// This method creates customers and adds them to the queue.
        /// A random delay is applied to simulate the time between customer arrivals.
        /// </summary>
        public void Start()
        {
            for (int i = 1; i <= _totalCustomers; i++)
            {
                //Arrival delay
                var delay = (int)(_random.NextDouble() * 1000);

                //Assign a random vehicle brand
                VehicleBrand brand = i % 2 == 0 ? VehicleBrand.Honda : VehicleBrand.Toyota;
                Car car = VehicleFactory.CreateCar(brand);

                Customer customer = new(i, car);

                //Print arrival
                _logger.Log($"Customer {customer.Id} has arrived. {customer.Car}{Environment.NewLine}{customer.Car.CarTire}");

                try
                {
                    _queue.Add(customer);
                }
                catch (InvalidOperationException)
                {
                    
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
