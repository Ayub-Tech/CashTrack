using CashTrack.Application.DTOs;
using FluentValidation;

namespace CashTrack.Application.Validators
{
    // Validates input when creating or updating categories
    public class CategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryValidator()
        {
            // Name is required
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required");

            // Name must be between 2 and 100 characters
            RuleFor(x => x.Name)
                .Length(2, 100)
                .WithMessage("Category name must be between 2 and 100 characters");
        }
    }
}