using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FittingShop.Logging;

namespace FittingShop.Simulation
{
    public class ShopSimulator
    {
        private readonly int _totalCustomers;
        private readonly int _workerCount;
        private readonly BlockingCollection<Customer> _queue = new BlockingCollection<Customer>();
        private readonly CountdownEvent _latch;

        public ShopSimulator(int workerCount, int totalCustomers)
        {
            _workerCount = workerCount;
            _totalCustomers = totalCustomers;
            _latch = new CountdownEvent(totalCustomers);
        }

        public void Start()
        {
            Logger logger = Logger.Instance;
            logger.SetStartTime(DateTime.UtcNow.Ticks);
            var tasks = new List<Task>();
            // Start workers using Tasks
            for (int i = 0; i < _workerCount; i++)
            {
                Worker worker = new Worker(_queue, _latch, logger);
                tasks.Add(Task.Run(() => worker.Run()));
            }

            // Start customer arrival
            var arrivalScheduler = new CustomerArrivalScheduler(_totalCustomers, _queue, logger);
            arrivalScheduler.Start();

            // Wait for all customers to be processed
            try
            {
                _latch.Wait(); // Blocks until latch count reaches 0

                Task.WaitAll([.. tasks]);
            }
            catch (Exception e)
            {
                throw new Exception("Simulation interrupted", e);
            }
        }
    }
}
