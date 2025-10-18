using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantRepository(ApplicationDbContext context) : IRestaurantRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await context.Restaurants.Include(r => r.Dishes).ToListAsync();

            return restaurants;
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
           var restaurant = await context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);
            return restaurant!;
        }
    }
}
