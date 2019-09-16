using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Web.Models;
namespace StarWars.Web.Brokers
{
    public class PeopleStorageBroker : DbContext, IStorageBroker<People>
    {
        private DbSet<People> Peoples { get; set; }
        public async Task AddEntity(People people)
        {
            try
            {
                await this.Peoples.AddAsync(people);
                await this.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
        }
    }
}