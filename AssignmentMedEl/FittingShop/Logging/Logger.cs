using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FittingShop.Logging
{
    public class Logger
    {
        private static readonly Logger _instance = new();
        private long _startTime;

        // Lock object for synchronization
        private readonly object _lock = new();

        // Private constructor to enforce singleton
        private Logger() { }

        public static Logger Instance => _instance;

        public void SetStartTime(long startTime)
        {
            _startTime = startTime;
        }

        public void Log(string message)
        {
            lock (_lock)
            {
                double timestamp = (DateTime.UtcNow.Ticks - _startTime) / 1_000_0000.0;
                Console.WriteLine($"{timestamp:F1} {message}");
            }
        }
    }
}
