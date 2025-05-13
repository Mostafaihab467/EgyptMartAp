namespace EgyptMart.Services.CMSAPI.Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;

        public FileLoggerProvider(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_path);
        }

        public void Dispose()
        {
            // No resources to dispose of in this example.
        }

        private class FileLogger : ILogger
        {
            private readonly string _filePath;
            private static readonly object _lock = new object();

            public FileLogger(string filePath)
            {
                _filePath = filePath;
            }

            public IDisposable BeginScope<TState>(TState state) => null;

            public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (!IsEnabled(logLevel))
                    return;

                if (formatter == null)
                    throw new ArgumentNullException(nameof(formatter));

                string message = formatter(state, exception);
                if (string.IsNullOrWhiteSpace(message))
                    return;

                string logRecord = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logLevel}] {message} {Environment.NewLine}";
                if (exception != null)
                {
                    logRecord += $"{exception}{Environment.NewLine}";
                }

                lock (_lock)
                {
                    File.AppendAllText(_filePath, logRecord);
                }
            }
        }


    }
}
