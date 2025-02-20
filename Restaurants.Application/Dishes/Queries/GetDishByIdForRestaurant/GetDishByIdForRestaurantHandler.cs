
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdFromRestaurant
{
    public class GetDishByIdFromRestaurantHandler(ILogger<GetDishByIdFromRestaurantHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository)
        : IRequestHandler<GetDishByIdFromRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdFromRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}",
                request.Id,
                request.RestaurantId);

            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.Id);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.Id.ToString());

            var result = mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
