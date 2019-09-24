using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.Web.Models;
using StarWars.Web.Services;

namespace StarWars.Web.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IStarWarsApiClient starWarsApiClient;
        private readonly IPeopleService peopleService;

        public DataController(IStarWarsApiClient starWarsApiClient, IPeopleService peopleService)
        {
            this.starWarsApiClient = starWarsApiClient;
            this.peopleService = peopleService;
        }
        // GET: api/data/peoples
        [HttpGet]
        public async Task<PeopleRootObject> GetPeopleAsync(string entity, string pageUrl)
        {
            try
            {
                return await this.starWarsApiClient.GetAsync(entity, pageUrl);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task Post(People people)
        {
            try
            {
                return await this.peopleService.AddPeopleToStarWarsWorld(people);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}