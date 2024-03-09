using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetAllTransactions
{
    public record GetAllTransactionsQuery : IRequest<Result>;
}
