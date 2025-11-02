using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Database;

namespace Restaurants.Infrastructure.Repositories;

public class DishRepository(ApplicationDbContext context) : IDishRepository
{
    public async Task<int> Create(Dish dish)
    {
        context.Dishes.Add(dish);
        await context.SaveChangesAsync();

        return dish.Id;
    }

    public async Task DeleteAsync(Dish dish)
    {
        context.Dishes.Remove(dish);
        await context.SaveChangesAsync();
    }

    public async Task<List<Dish>> GetAllByRestaurantIdAsync(int restaurantId)
    {
        var dishes = await Task.FromResult(context.Dishes.Where(d => d.RestaurantId == restaurantId).ToList());

        return dishes;
    }

    public async Task<Dish?> GetByIdAsync(int dishId)
    {
        var dish = await context.Dishes.FindAsync(dishId);
        return dish;
    }
}
