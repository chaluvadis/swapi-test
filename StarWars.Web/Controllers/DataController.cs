using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.Web.Models;
using StarWars.Web.Services;

namespace StarWars.Web.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ResponseCache(CacheProfileName = "Default30")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IStarWarsApiClient starWarsApiClient;

        public DataController(IStarWarsApiClient starWarsApiClient) => this.starWarsApiClient = starWarsApiClient;
        // GET: api/data/peoples
        [HttpGet]
        public async Task<PeopleRootObject> GetPeopleAsync(string queryString)
        {
            try
            {
                return await this.starWarsApiClient.GetAsync(queryString);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task PostPeopleAsync(People people)
        {
            try
            {
                await this.starWarsApiClient.AddPeopleAsnyc(people);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}