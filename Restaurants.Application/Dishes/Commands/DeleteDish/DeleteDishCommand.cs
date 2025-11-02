using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommand:IRequest
{
    public int RestaurantId { get; }
    public int DishId { get; }
    public DeleteDishCommand(int restaurantId, int dishId)
    {
        RestaurantId = restaurantId;
        DishId = dishId;
    }
}
