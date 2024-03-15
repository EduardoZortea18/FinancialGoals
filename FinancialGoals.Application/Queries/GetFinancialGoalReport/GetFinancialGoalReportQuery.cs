using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetFinancialGoalReport
{
    public sealed record GetFinancialGoalReportQuery(Guid FinancialGoalId) : IRequest<GenericResult<string>>;
}
