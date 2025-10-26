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
        ILogger<CreateRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling DeleteRestaurantCommand for Restaurant Id: {RestaurantId}", request.Id);
            bool isDelted = await restaurantRepository.DeleteAsync(request.Id);

            return isDelted;
        }
    }
}
