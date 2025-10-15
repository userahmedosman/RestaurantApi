using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
