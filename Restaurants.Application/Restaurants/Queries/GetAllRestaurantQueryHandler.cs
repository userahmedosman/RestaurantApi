using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dto;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries;

public class GetAllRestaurantQueryHandler(IRestaurantRepository restaurantRepository,
        ILogger<GetAllRestaurantQueryHandler> logger,
        IMapper mapper) : IRequestHandler<GetAllRestaurantQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all restaurants from the repository.");
        var restaurants = await restaurantRepository.GetAllAsync();
        List<RestaurantDto> dto = mapper.Map<List<RestaurantDto>>(restaurants);

        return dto!;
    }
}
