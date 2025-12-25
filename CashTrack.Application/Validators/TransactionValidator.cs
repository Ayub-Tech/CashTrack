using CashTrack.Application.DTOs;
using FluentValidation;

namespace CashTrack.Application.Validators
{
    // Validates input when creating or updating transactions
    public class TransactionValidator : AbstractValidator<CreateTransactionDto>
    {
        public TransactionValidator()
        {
            // Amount is required and must be greater than 0
            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0");

            // Date is required
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required");

            // UserId is required and must be greater than 0
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("Valid User ID is required");

            // CategoryId is required and must be greater than 0
            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Valid Category ID is required");
        }
    }
}
