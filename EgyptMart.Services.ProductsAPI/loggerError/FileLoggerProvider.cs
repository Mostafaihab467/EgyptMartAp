namespace EgyptMart.Services.ProductsAPI.loggerError
{
    public class FileLoggerProvider(string filePath) : ILoggerProvider
    {
        private readonly string _filePath = filePath;

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filePath);
        }

        public void Dispose() { }
    }
}
