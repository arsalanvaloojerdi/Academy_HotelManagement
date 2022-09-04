using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Infrastructure.Persistence.EntityConfigurations.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelEntityConfiguration).Assembly);
        }
    }
}