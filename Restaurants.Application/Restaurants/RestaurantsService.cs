﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto!;
    }
    
    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }
}
