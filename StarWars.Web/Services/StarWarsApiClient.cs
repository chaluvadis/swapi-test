using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Web.Brokers;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IStorageBroker<People> storageBroker;
        // private readonly ILoggingBroker loggingBroker;
        public StarWarsApiClient(IHttpClientFactory httpClientFactory, IStorageBroker<People> storageBroker)
        {
            this.httpClientFactory = httpClientFactory;
            this.storageBroker = storageBroker;
        }
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

        public async Task AddPeopleAsnyc(People people)
        {
            try
            {
                await this.storageBroker.AddEntity(people);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
        }
        // Add extra methods for neew entities
    }
}