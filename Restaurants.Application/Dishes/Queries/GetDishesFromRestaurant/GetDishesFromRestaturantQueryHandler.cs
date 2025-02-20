
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishesFromRestaurant;

public class GetDishesFromRestaturantQueryHandler(ILogger<GetDishesFromRestaturantQueryHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<GetDishesFromRestaturantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesFromRestaturantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return results;
    }
}
