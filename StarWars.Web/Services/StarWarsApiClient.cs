using System.Net.Http;
using System.Threading.Tasks;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private const string PeopleHostPath = "people";
        // private readonly ILoggingBroker loggingBroker;
        public StarWarsApiClient(IHttpClientFactory httpClientFactory) => this.httpClientFactory = httpClientFactory;
        public async Task<PeopleRootObject> GetAsync(string queryString)
        {
            try
            {
                var client = httpClientFactory.CreateClient("swapiClient");
                var finalUrl = client.BaseAddress.AbsoluteUri + queryString;
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
        // Add extra methods for neew entities
    }
}