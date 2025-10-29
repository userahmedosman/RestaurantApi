using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, 
    IRestaurantRepository restaurantRepository,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling UpdateRestaurantCommand for Restaurant Id: {RestaurantId}", request.Id);
        var restaurantToUpdate = mapper.Map<Domain.Entities.Restaurant>(request);
        await restaurantRepository.UpdateAsync(request.Id, restaurantToUpdate);

    }
}
