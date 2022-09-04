using HotelManagement.Application.Implements;
using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using HotelManagement.Infrastructure.Persistence;
using HotelManagement.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void WireUp(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
        }
    }
}
