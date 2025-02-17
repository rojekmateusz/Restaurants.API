﻿using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {   
        var restaurants = await restaurantService.GetAllRestaurants();
        return Ok(restaurants);
    }
}
