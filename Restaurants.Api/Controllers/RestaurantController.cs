using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Api.Controllers
{
    [Route("restaurants")]
    [ApiController]
    public class RestaurantController(IRestaurantsService restaurantsService) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await restaurantsService.GetAllRestaurantAsync();

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            var restaurant = await restaurantsService.GetRestaurantByIdAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);


        }
    }
}
