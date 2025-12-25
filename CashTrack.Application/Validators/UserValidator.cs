using CashTrack.Application.DTOs;
using FluentValidation;

namespace CashTrack.Application.Validators
{
    // Validates input when creating or updating users
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            // Name is required
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            // Name must be between 2 and 100 characters
            RuleFor(x => x.Name)
                .Length(2, 100)
                .WithMessage("Name must be between 2 and 100 characters");

            // Email is required
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            // Email must be valid format
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email must be a valid email address");

            // Email max length
            RuleFor(x => x.Email)
                .MaximumLength(255)
                .WithMessage("Email cannot exceed 255 characters");
        }
    }
}
