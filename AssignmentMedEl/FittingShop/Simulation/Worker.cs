using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FittingShop.Logging;

namespace FittingShop.Simulation
{
    public class Worker
    {
        private readonly BlockingCollection<Customer> _queue;
        private readonly Logger _logger;
        private readonly Random _random = new Random();
        private readonly CountdownEvent _latch;

        public Worker(BlockingCollection<Customer> queue, CountdownEvent latch, Logger logger)
        {
            _queue = queue;
            _latch = latch;
            _logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    if (_latch.CurrentCount == 0)
                        break;

                    
                    bool success = _queue.TryTake(out Customer customer, TimeSpan.FromMilliseconds(500));

                    if (!success)
                        continue;

                    float duration = 2.0f + (float)_random.NextDouble() * 3.0f;

                    _logger.Log($"Customer {customer.Id} car tires are being changed and it will take {duration:F1} seconds.");
                    Thread.Sleep((int)(duration * 1000));
                    _logger.Log($"Customer {customer.Id} has left.");

                    _latch.Signal();
                }
                catch (ThreadInterruptedException)
                {
                    Thread.CurrentThread.Interrupt();
                }
            }
        }
    }
}
