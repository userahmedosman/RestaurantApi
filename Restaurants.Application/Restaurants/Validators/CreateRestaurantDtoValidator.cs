
using FluentValidation;
using Restaurants.Application.Restaurants.Dto;

namespace Restaurants.Application.Restaurants.Validators;
public class CreateRestaurantDtoValidator:AbstractValidator<CreateRestaurantDto>
{
    public CreateRestaurantDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restaurant name is required.")
            .Length(5, 100).WithMessage("Restaurant name must not be less than 5 characters or exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(3000).WithMessage("Address must not exceed 3000 characters.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.");
        RuleFor(x => x.ContactNumber)
          .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Contact email is not valid.");
        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}(-\d{3})?$").WithMessage("Postal code is not valid. valid format is -> XX-XXX");
    }
}
