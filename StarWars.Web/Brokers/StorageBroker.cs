using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Web.Models;
namespace StarWars.Web.Brokers
{
    public class StorageBroker : DbContext, IStorageBroker<People>
    {
        private DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().IsMemoryOptimized();
            Database.EnsureCreated();
        }

        public async Task AddEntity(People people)
        {
            try
            {
                await this.Peoples.Add(people);
                await this.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw dbUpdateException;
            }
        }
    }
}

