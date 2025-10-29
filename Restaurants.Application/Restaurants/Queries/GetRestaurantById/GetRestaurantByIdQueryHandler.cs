using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository,
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Fetching  restaurant with ID={request.Id}");

        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        var dto = mapper.Map<RestaurantDto>(restaurant);
        return dto;
    }
}
