using HotelManagement.Domain.Models.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infrastructure.Persistence.EntityConfigurations.Hotels
{
    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200);
            builder.OwnsOne(p => p.Address, navigationBuilder =>
            {
                navigationBuilder.Property(p => p.City).HasMaxLength(100);
                navigationBuilder.Property(p => p.Details).HasMaxLength(500);
            });

            builder.ToTable("Hotels");
        }
    }
}