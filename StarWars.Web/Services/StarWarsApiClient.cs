using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StarWars.Web.Brokers;
using StarWars.Web.Models;

namespace StarWars.Web.Services
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILoggingBroker loggingBroker;
        public StarWarsApiClient(
            IHttpClientFactory httpClientFactory,
            ILoggingBroker loggingBroker)
        {
            this.httpClientFactory = httpClientFactory;
            this.loggingBroker = loggingBroker;
        }
        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient("twitterClient");
                Uri endpoint = client.BaseAddress;
                var finalUrl = endpoint.AbsoluteUri + "people";
                var request = new HttpRequestMessage(HttpMethod.Get, finalUrl);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<People>>();
                }
                return Array.Empty<People>();
            }
            catch (System.Exception)
            {
                this.loggingBroker.Error("Error in getting People data from Swapi client");
                throw;
            }
        }

        // Add extra methods for neew entities
    }
}