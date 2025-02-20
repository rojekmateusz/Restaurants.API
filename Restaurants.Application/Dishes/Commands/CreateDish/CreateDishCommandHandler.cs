

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IMapper mapper, IRestaurantRepository repository, 
    IDishesRepository dishesRepository) : IRequestHandler<CreateDishCommand>
{
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish: {@DishRequest}", request);
        var restaurant = await repository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }

        var dishMapper = mapper.Map<Dish>(request);
        await dishesRepository.Create(dishMapper);
    }
}
