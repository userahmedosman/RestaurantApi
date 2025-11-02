using MediatR;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQuery:IRequest<DishDto?>
{
    public int RestaurantId { get; }
    public int DishId { get; }
    public GetDishByIdQuery(int restaurantId, int dishId)
    {
        RestaurantId = restaurantId;
        DishId = dishId;
    }
}
