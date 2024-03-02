using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.RemoveTransaction
{
    public sealed record RemoveTransactionCommand(Guid Id) : IRequest<Result>;
}
