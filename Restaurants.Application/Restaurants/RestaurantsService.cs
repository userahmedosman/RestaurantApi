using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(
        IRestaurantRepository restaurantRepository, 
        ILogger<RestaurantsService> logger,
        IMapper mapper) : IRestaurantsService
    {

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantAsync()
        {
            logger.LogInformation("Fetching all restaurants from the repository."); 
            var restaurants = await restaurantRepository.GetAllAsync();
            List<RestaurantDto> dto = mapper.Map<List<RestaurantDto>>(restaurants);

            return dto!;
        }

        public async Task<RestaurantDto> GetRestaurantByIdAsync(int id)
        {
            logger.LogInformation($"Fetching  restaurant with ID={id}");

            var restaurant = await restaurantRepository.GetByIdAsync(id);
            var dto = mapper.Map<RestaurantDto>(restaurant);
            return dto;
        }
    }
}
