using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CppPinvokeGenerator
{
    public static class LoggerFactory
    {
        private static ILoggerFactory _loggerFactory;

        public static void RegisterLoggerFactory(ILoggerFactory loggerFactory) 
            => _loggerFactory = loggerFactory;

        public static ILogger GetLogger<T>()
        {
            if (_loggerFactory == null)
                return NullLogger<T>.Instance;
            return _loggerFactory.CreateLogger<T>();
        }
    }
}
