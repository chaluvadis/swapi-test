using System.Threading.Tasks;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public interface IStarWarsApiClient
    {
        // api returns data in pages, passing page number as parameter
        Task<PeopleRootObject> GetAsync(string queryString);

        // Add extra methods for neew entities
    }
}