using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Application.Dishes.Queries;

namespace Restaurants.Api.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        command.RestaurantId = restaurantId;
        await mediator.Send(command);
        return Created();
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult> GetDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdQuery(restaurantId, dishId));
        if (dish is null)
        {
            return NotFound();
        }
        return Ok(dish);
    }

    [HttpDelete("{dishId}")]
    public async Task<ActionResult> DeleteDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var command = new DeleteDishCommand(restaurantId, dishId);
        await mediator.Send(command);
        return NoContent();
    }
}
