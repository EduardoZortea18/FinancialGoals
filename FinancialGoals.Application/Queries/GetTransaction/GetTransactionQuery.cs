using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetTransaction
{
    public record GetTransactionQuery(Guid Id) : IRequest<Result>;
}
