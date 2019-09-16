using System.Collections.Generic;
using System.Net.Http;
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

        public DataController(IStarWarsApiClient starWarsApiClient) => this.starWarsApiClient = starWarsApiClient;
        // GET: api/data/peoples
        [HttpGet]
        [Route("people")]
        public async Task<PeopleRootObject> GetPeopleAsync()
        {
            try
            {
                return await this.starWarsApiClient.GetPeopleAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}