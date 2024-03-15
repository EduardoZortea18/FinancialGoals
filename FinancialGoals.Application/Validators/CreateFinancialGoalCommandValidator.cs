using FinancialGoals.Application.Commands.CreateFinancialGoal;
using FluentValidation;

namespace FinancialGoals.Application.Validators
{
    public class CreateFinancialGoalCommandValidator : AbstractValidator<CreateFinancialGoalCommand>
    {
        public CreateFinancialGoalCommandValidator()
        {
            RuleFor(x => x.Deadline)
                .GreaterThan(DateTime.UtcNow)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Title)
                .MaximumLength(30)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.MonthlyAmount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
