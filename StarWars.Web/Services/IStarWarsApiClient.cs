using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public interface IStarWarsApiClient
    {
        Task<IEnumerable<People>> GetPeopleAsync();

        // Add extra methods for neew entities
    }
}