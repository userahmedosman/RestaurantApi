using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQueryHandler(ILogger<GetAllDishesQueryHandler> logger,
    IMapper mapper, IDishRepository dishRepository) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetAllDishesQuery for RestaurantId: {RestaurantId}", request.RestaurantId);

        var dishes = await dishRepository.GetAllByRestaurantIdAsync(request.RestaurantId);

        if (dishes == null)
        {
            throw new NotFoundException($"No dishes found for RestaurantId: {request.RestaurantId}");
        }

        var dishDtos = mapper.Map<IEnumerable<DishDto>>(dishes);

        return dishDtos;
    }
}
