namespace FittingShop.Logging
{
    /// <summary>
    /// Provides a logger to print execution details with a timestamp
    /// </summary>
    public class Logger
    {
        private static readonly Logger _instance = new();
        private long _startTime;

        // Lock for synchronization
        private readonly object _lock = new();

        
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
