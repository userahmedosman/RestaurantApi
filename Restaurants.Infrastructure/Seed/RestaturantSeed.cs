using Restaurants.Infrastructure.Database;

namespace Restaurants.Infrastructure.Seed
{
    internal class RestaturantSeed(ApplicationDbContext context) : IRestaturantSeed
    {
        public async Task Seed()
        {
            if (context.Database.CanConnect())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = RestaurantsList();
                    await context.Restaurants.AddRangeAsync(restaurants);
                    await context.SaveChangesAsync();
                }
            }
        }

        private List<Domain.Entities.Restaurant> RestaurantsList()
        {
            var restaurants = new List<Domain.Entities.Restaurant>
                    {
                        new Domain.Entities.Restaurant
                        {
                            Name = "The Gourmet Kitchen",
                            Description = "A fine dining experience with international cuisine.",
                            HasDelivery = true,
                            Category = "Restaurant",
                            ContactEmail = "thegourmetkitchen@gmail.com",
                            ContactNumber = "4112-0025",
                            Address = new Domain.Entities.Address
                            {
                                Street = "110 GreenTower Ln",
                                City = "Texas",
                                PostalCode = "58841"
                            },
                            Dishes = new List<Domain.Entities.Dish>
                            {
                                new Domain.Entities.Dish
                                {
                                    Name = "Truffle Pasta",
                                    Description = "Pasta with fresh truffles and parmesan.",
                                    Price = 25.99m
                                },
                                new Domain.Entities.Dish
                                {
                                    Name = "Seared Scallops",
                                    Description = "Scallops seared to perfection with a lemon butter sauce.",
                                    Price = 30.50m
                                }
                            }

                        },

                        new Domain.Entities.Restaurant
                        {
                            Name = "Burger Haven",
                            Description = "The best burgers in town with a variety of toppings.",
                            HasDelivery = true,
                            Category = "Fast Food",
                            ContactEmail = "burgerheave@gmail.com",
                            ContactNumber = "555-1234",
                            Address = new Domain.Entities.Address
                            {
                                Street = "456 Burger Ln",
                                City = "Grilltown",
                                PostalCode = "78901"
                            },
                            Dishes = new List<Domain.Entities.Dish>
                            {
                                new Domain.Entities.Dish
                                {
                                    Name = "Classic Cheeseburger",
                                    Description = "Juicy beef patty with cheddar cheese, lettuce, tomato, and our special sauce.",
                                    Price = 10.99m
                                },
                                new Domain.Entities.Dish
                                {
                                    Name = "Bacon Avocado Burger",
                                    Description = "Beef patty topped with crispy bacon, fresh avocado, and pepper jack cheese.",
                                    Price = 12.99m
                                }
                            }
                        }
                    };
            return restaurants;
        }

    }
}
