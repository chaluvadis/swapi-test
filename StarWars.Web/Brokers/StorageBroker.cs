using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Web.Models;
using StarWars.Web.Context;
namespace StarWars.Web.Brokers
{
    public class StorageBroker : IStorageBroker<People>
    {
        private readonly StorageContext strorageContext;
        public StorageBroker(StorageContext storageConext)
            => this.strorageContext = storageConext;

        public async Task AddEntity(People people)
        {
            try
            {
                await this.strorageContext.Peoples.AddAsync(people);
                await this.strorageContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
        }
    }
}

