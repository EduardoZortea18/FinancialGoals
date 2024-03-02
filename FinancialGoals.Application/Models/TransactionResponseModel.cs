using FinancialGoals.Domain.Enums;

namespace FinancialGoals.Application.Models
{
    public sealed record TransactionResponseModel(
        Guid Id,
        decimal Amount,
        TransactionType TransactionType,
        DateTime Date,
        Guid FinancialGoalId);
}
