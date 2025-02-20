using MediatR;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdFromRestaurant;

public class GetDishByIdFromRestaurantQuery(int restaurantID, int dishId): IRequest<DishDto>
{
    public int Id { get; set; }  = dishId;
    public int RestaurantId { get; set; } = restaurantID;
}
