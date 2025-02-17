
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }

    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restuarants = new()
        {
            new Restaurant
            {
                Name = "McDonald's",
                Description = "The best fast food in the world",
                Category = "Fast Food",
                HasDelivery = true,
                Address = new Address
                {
                    City = "New York",
                    Street = "Broadway",
                    PostalCode = "10001"
                },
                Dishes = new List<Dish>
                {
                    new Dish
                    {
                        Name = "Big Mac",
                        Description = "The best burger in the world",
                        Price = 5.99m
                    },
                    new Dish
                    {
                        Name = "Cheeseburger",
                        Description = "The best cheeseburger in the world",
                        Price = 2.99m
                    }
                }
            },
            new Restaurant
            {
                Name = "Burger King",
                Description = "The best fast food in the world",
                Category = "Fast Food",
                HasDelivery = true,
                Address = new Address
                {
                    City = "New York",
                    Street = "Broadway",
                    PostalCode = "10001"
                },
                Dishes = new List<Dish>
                {
                    new Dish
                    {
                        Name = "Whopper",
                        Description = "The best burger in the world",
                        Price = 5.99m
                    },
                    new Dish
                    {
                        Name = "Cheeseburger",
                        Description = "The best cheeseburger in the world",
                        Price = 2.99m
                    }
                }
            }
        };

        return restuarants;
    }
}
