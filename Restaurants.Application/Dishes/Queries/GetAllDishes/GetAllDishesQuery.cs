using MediatR;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQuery:IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; }
    public GetAllDishesQuery(int restaurantId)
    {
        RestaurantId = restaurantId;
    }
}
