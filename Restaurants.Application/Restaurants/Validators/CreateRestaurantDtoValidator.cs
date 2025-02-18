
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private List<string> validCategory = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");
        RuleFor(dto => dto.Category)
            .Must(validCategory.Contains)
            .WithMessage("Invalid category.Please choose from the valid categories");
    }
}
