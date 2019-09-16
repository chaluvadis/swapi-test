using Microsoft.Extensions.Logging;

namespace StarWars.Web.Brokers
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;
        public LoggingBroker(ILogger logger) => this.logger = logger;
        public void Error(string message) => this.logger.LogError(message);
        public void Information(string message) => this.logger.LogInformation(message);
    }
}