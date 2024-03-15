using FinancialGoals.Application.Commands.CreateTransaction;
using FluentValidation;

namespace FinancialGoals.Application.Validators
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.Date)
                .GreaterThanOrEqualTo(DateTime.Now)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FinancialGoalId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
