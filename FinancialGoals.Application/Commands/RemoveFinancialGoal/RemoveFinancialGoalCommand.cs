using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.RemoveFinancialGoal
{
    public sealed record RemoveFinancialGoalCommand(Guid Id) : IRequest<Result>;
}
