using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurantAsync();

        Task<RestaurantDto> GetRestaurantByIdAsync(int id);
    }
}