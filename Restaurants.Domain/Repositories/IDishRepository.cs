using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishRepository
{
    Task<int> Create(Dish dish);

    Task<List<Dish>> GetAllByRestaurantIdAsync(int restaurantId);
    Task<Dish?> GetByIdAsync(int dishId);

    Task DeleteAsync(Dish dish);
}
