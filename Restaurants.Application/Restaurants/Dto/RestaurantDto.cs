using Restaurants.Domain.Entities;
using Restaurants.Application.Dishes.Dto;
namespace Restaurants.Application.Restaurants.Dto
{
    public sealed record RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public bool HasDelivery { get; set; }

        public Address? Address { get; set; }

        public List<DishDto> Dishes { get; set; } = [];
    }
}
