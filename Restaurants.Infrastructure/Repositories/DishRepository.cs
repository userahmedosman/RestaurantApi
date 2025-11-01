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
}
