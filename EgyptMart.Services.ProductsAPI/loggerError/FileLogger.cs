
namespace EgyptMart.Services.ProductsAPI.loggerError
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
        }

        IDisposable? ILogger.BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            return;

            //if (!IsEnabled(logLevel)) return;

            //var message = $"{DateTime.Now} [{logLevel}] {formatter(state, exception)}";

            //if (exception != null)
            //{
            //    message += Environment.NewLine + exception.ToString();
            //}

            //File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
