using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Application.Restaurants.Queries;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Api.Controllers
{
    [Route("restaurants")]
    [ApiController]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantQuery());

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            await mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand create)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            int id = await mediator.Send(create);

            if(id <= 0)
            {
                return BadRequest("Could not create restaurant");
            }

            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditRestaurant( UpdateRestaurantCommand update, [FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            update.Id = Id;
            await mediator.Send(update);

          
            return NoContent();
           
        }

     }
}
