using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, 
    IRestaurantRepository restaurantRepository,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling UpdateRestaurantCommand for Restaurant Id: {RestaurantId}", request.Id);
        var restaurantToUpdate = mapper.Map<Domain.Entities.Restaurant>(request);
        var result = await restaurantRepository.UpdateAsync(request.Id, restaurantToUpdate);

        return result;
    }
}
