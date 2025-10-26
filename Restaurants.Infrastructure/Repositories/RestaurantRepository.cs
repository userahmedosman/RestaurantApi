using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Database;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantRepository(ApplicationDbContext context) : IRestaurantRepository
    {
        public async Task<int> CreateAsync(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();

            return restaurant.Id;
        }

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

        public async Task<bool> DeleteAsync(int id)
        {
            bool result = false;
            var restaurant = await context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
                await context.SaveChangesAsync();
                result = true;

            }

            return result;
        }

        public async Task<bool> UpdateAsync(int id, Restaurant restaurant)
        {
            var restaurantToUpdate = await context.Restaurants.FindAsync(id);
            if (restaurantToUpdate != null)
            {
                restaurantToUpdate.Name = restaurant.Name;
                restaurantToUpdate.Description = restaurant.Description;
                restaurantToUpdate.Category = restaurant.Category;
                restaurantToUpdate.HasDelivery = restaurant.HasDelivery;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
