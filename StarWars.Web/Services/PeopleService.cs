using System.Threading.Tasks;
using StarWars.Web.Brokers;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IStorageBroker<People> storageBroker;
        public PeopleService(IStorageBroker<People> storageBroker) => this.storageBroker = storageBroker;
        Task IPeopleService.AddPeopleToStarWarsWorld(People people) => throw new System.NotImplementedException();
    }
}