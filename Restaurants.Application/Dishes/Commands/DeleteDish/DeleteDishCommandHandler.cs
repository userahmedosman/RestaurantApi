using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;
namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommandHandler(
    ILogger<DeleteDishCommandHandler> logger,
    IRestaurantRepository restaurantRepository,
    IDishRepository dishRepository) : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting dish {DishId} from restaurant {RestaurantId}", request.DishId, request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found");
        }

        var dish = await dishRepository.GetByIdAsync(request.DishId);   
        if (dish is null || dish.RestaurantId != request.RestaurantId)
        {
            throw new NotFoundException($"Dish with id {request.DishId} not found in restaurant {request.RestaurantId}");
        }
        await dishRepository.DeleteAsync(dish);
    }
}
