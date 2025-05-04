using System.Collections.Concurrent;
using FittingShop.Logging;

namespace FittingShop.Simulation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShopSimulator"/> class.
    /// Creates worker Threads.
    /// Initializes <see cref="CustomerArrivalScheduler"/> and starts the arrival scheduling.
    /// </summary>
    /// <param name="workerCount">Number of worker Threads.</param>
    /// <param name="totalCustomers">Total amount of customers to be handled.</param>
    public class ShopSimulator(int workerCount, int totalCustomers)
    {
        private readonly int _totalCustomers = totalCustomers;
        private readonly int _workerCount = workerCount;
        private readonly BlockingCollection<Customer> _queue = [];
        private readonly CountdownEvent _latch = new(totalCustomers);

        /// <summary>
        /// Launches worker Threads and initiates the customer arrival.
        /// Waits until all workers finish their tasks.
        /// </summary>
        /// <exception cref="Exception">Thrown if the simulation is interrupted.</exception>
        public void Start()
        {
            Logger logger = Logger.Instance;
            logger.SetStartTime(DateTime.UtcNow.Ticks);
            var tasks = new List<Task>();

            //Start workers
            for (int i = 0; i < _workerCount; i++)
            {
                Worker worker = new(_queue, _latch, logger);
                tasks.Add(Task.Run(() => worker.Run()));
            }

            //Start customer arrival 
            var arrivalScheduler = new CustomerArrivalScheduler(_totalCustomers, _queue, logger);
            arrivalScheduler.Start(); 
            
            //Wait for all workers to finish
            try
            {
                Task.WaitAll([.. tasks]);
            }
            catch (Exception e)
            {
                throw new Exception("Simulation interrupted", e);
            }
        }
    }
}
