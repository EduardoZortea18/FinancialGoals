using FinancialGoals.Domain.Enums;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateTransaction
{
    public sealed record CreateTransactionCommand(
        decimal Amount,
        TransactionType TransactionType,
        DateTime Date,
        Guid FinancialGoalId) : IRequest<Result>;
}
