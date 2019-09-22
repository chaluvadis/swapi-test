using Microsoft.EntityFrameworkCore;
using StarWars.Web.Models;
namespace StarWars.Web.Context
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions options)
        : base(options)
        { }
        public DbSet<People> Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().ToTable("Peoples");
        }
    }
}