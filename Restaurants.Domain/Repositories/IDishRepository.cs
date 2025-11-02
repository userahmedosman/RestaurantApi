using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishRepository
{
    Task<int> Create(Dish dish);
    Task<Dish?> GetByIdAsync(int dishId);

    Task DeleteAsync(Dish dish);
}
