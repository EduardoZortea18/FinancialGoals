using FinancialGoals.Domain.Enums;

namespace FinancialGoals.Application.Models
{
    public sealed record FinancialGoalResponseModel(
        Guid? Id,
        string Title,
        decimal TargetAmount,
        DateTime Deadline,
        decimal MonthlyAmount,
        FinancialGoalStatus Status,
        decimal ActualAmount);
}
