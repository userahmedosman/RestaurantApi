using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dto;
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

        [HttpPost]
        public async Task<ActionResult> CreateRestaurant([FromBody] CreateRestaurantDto create)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            int id = await restaurantsService.CreateRestaurantAsync(create);

            if(id <= 0)
            {
                return BadRequest("Could not create restaurant");
            }

            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }
    }
}
