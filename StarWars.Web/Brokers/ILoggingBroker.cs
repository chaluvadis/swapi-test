using System;

namespace StarWars.Web.Brokers
{
    public interface ILoggingBroker
    {
        void Error(string message);
        void Information(string message);
    }
}