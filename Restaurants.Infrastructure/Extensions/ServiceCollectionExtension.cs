using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Database;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seed;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRestaturantSeed, RestaturantSeed>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
