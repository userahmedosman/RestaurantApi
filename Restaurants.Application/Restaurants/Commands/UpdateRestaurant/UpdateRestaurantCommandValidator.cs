using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator:AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restaurant name is required.")
            .Length(5, 100).WithMessage("Restaurant name must not be less than 5 characters or exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(3000).WithMessage("Address must not exceed 3000 characters.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.");
    }
}
