using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Mapper;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}
