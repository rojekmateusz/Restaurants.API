
using MediatR;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Queries.GetDishesFromRestaurant;

public class GetDishesFromRestaturantQuery(int restaurantId) : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; } = restaurantId;
}
