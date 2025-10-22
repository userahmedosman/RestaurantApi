using MediatR;
using Restaurants.Application.Restaurants.Dto;

namespace Restaurants.Application.Restaurants.Queries;

public class GetAllRestaurantQuery:IRequest<IEnumerable<RestaurantDto>>
{
}
