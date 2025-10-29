using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository,
        ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling DeleteRestaurantCommand for Restaurant Id: {RestaurantId}", request.Id);
            await restaurantRepository.DeleteAsync(request.Id);

        }
    }
}
