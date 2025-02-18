
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand,bool>
{
    public async  Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete Restaurant {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if(restaurant == null)
        {
            logger.LogWarning($"Restaurant {request.Id} not found");
            return false;
        }
        await restaurantRepository.Delete(restaurant);
        return true;
    }
}
