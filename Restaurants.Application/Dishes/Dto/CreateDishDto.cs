namespace Restaurants.Application.Dishes.Dto;

public sealed class CreateDishDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
