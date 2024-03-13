using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.UpdateFinancialGoal
{
    public sealed record UpdateFinancialGoalCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string title { get; init; }
        public decimal targetAmount { get; init; }
        public DateTime deadline { get; init; }
        public decimal monthlyAmount { get; init; }
    }
}
