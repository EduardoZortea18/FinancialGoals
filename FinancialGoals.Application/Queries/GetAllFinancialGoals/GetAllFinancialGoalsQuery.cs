using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetAllFinancialGoals
{
    public sealed record GetAllFinancialGoalsQuery : IRequest<Result>;
}
