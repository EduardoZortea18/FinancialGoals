using FinancialGoals.Domain.Enums;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.UpdateFinancialGoal
{
    public sealed record UpdateFinancialGoalCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Title { get; init; }
        public decimal TargetAmount { get; init; }
        public DateTime Deadline { get; init; }
        public decimal MonthlyAmount { get; init; }
        public FinancialGoalStatus Status { get; init; }
    }
}
