using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();

        Task<Restaurant> GetByIdAsync(int id);

        Task<int> CreateAsync(Restaurant restaurant);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(int id, Restaurant restaurant);
    }
}
