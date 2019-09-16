using System.Threading.Tasks;
using StarWars.Web.Brokers;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IStorageBroker<People> storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public PeopleService(
            IStorageBroker<People> storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        Task IPeopleService.AddPeopleToStarWarsWorld(People people)
        {
            throw new System.NotImplementedException();
        }
    }
}