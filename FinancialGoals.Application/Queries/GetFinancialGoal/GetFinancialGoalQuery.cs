using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetFinancialGoal
{
    public sealed record GetFinancialGoalQuery(Guid Id) : IRequest<Result>;
}
