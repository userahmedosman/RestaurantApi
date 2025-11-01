using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(
    ILogger<CreateDishCommandHandler> logger, 
    IMapper mapper, 
    IRestaurantRepository restaurantRepository,
    IDishRepository dishRepository) : IRequestHandler<CreateDishCommand>
{
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating dish {DishName} for restaurant {RestaurantId}.", request.Name, request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if(restaurant is null)
        {
            logger.LogWarning("Restaurant with id {RestaurantId} not found.", request.RestaurantId);
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }

        var dish = mapper.Map<Domain.Entities.Dish>(request);
      
        await dishRepository.Create(dish);

    }
}
