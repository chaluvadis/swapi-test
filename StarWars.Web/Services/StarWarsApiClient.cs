using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        // private readonly ILoggingBroker loggingBroker;
        public StarWarsApiClient(IHttpClientFactory httpClientFactory) => this.httpClientFactory = httpClientFactory;
        public async Task<PeopleRootObject> GetAsync(string entity, string pageUrl)
        {
            try
            {
                var client = httpClientFactory.CreateClient("swapiClient");
                // "https://swapi.co/api/people/?page=2"
                var finalUrl = $"{client.BaseAddress.AbsoluteUri}{entity}/{pageUrl}";
                var request = new HttpRequestMessage(HttpMethod.Get, finalUrl);
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PeopleRootObject>();
                }
                return new PeopleRootObject();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}