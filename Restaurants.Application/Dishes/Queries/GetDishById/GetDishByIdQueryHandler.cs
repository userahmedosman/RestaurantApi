using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQueryHandler
    (IMapper mapper,
    IRestaurantRepository restaurantRepository,
    ILogger<GetDishByIdQueryHandler> logger,
    IDishRepository dishRepository) : IRequestHandler<GetDishByIdQuery, DishDto?>
{
    public async Task<DishDto?> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetDishByIdQuery for RestaurantId: {RestaurantId}, DishId: {DishId}",
            request.RestaurantId, request.DishId);
        var restaurantExists = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurantExists is null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }
        var dish = await dishRepository.GetByIdAsync(request.DishId);
        if (dish is null || dish.RestaurantId != request.RestaurantId)
        {
            throw new NotFoundException($"Dish with id {request.DishId} not found in Restaurant with id {request.RestaurantId}.");
        }
        var dishDto = mapper.Map<DishDto>(dish);
        return dishDto;
    }
}
