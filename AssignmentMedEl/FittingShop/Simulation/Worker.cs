using System.Collections.Concurrent;
using FittingShop.Logging;

namespace FittingShop.Simulation
{
    /// <summary>
    /// Simulates a worker that processes customers from the queue.
    /// </summary>
    /// <param name="queue">Queue where customers are placed for processing.</param>
    /// <param name="latch">Latch to keep count of processed customers.</param>
    /// <param name="logger">Logger used to print execution details.</param>
    public class Worker(BlockingCollection<Customer> queue, CountdownEvent latch, Logger logger)
    {
        private readonly BlockingCollection<Customer> _queue = queue;
        private readonly Logger _logger = logger;
        private readonly Random _random = new();
        private readonly CountdownEvent _latch = latch;

        /// <summary>
        /// Starts the worker loop, to continuously fetch customers from the queue and simulate a tire change.
        /// </summary>
        public void Run()
        {
            while (_latch.CurrentCount != 0)
            {
                try
                {
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
