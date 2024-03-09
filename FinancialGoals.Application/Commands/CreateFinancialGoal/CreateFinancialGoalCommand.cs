using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateFinancialGoal
{
    public sealed record CreateFinancialGoalCommand(
        string Title,
        decimal TargetAmount,
        DateTime Deadline,
        decimal MonthlyAmount) : IRequest<Result>
    {
        public static implicit operator FinancialGoal(CreateFinancialGoalCommand dto)
            => new FinancialGoal(dto.Title, dto.TargetAmount, dto.Deadline, dto.MonthlyAmount);

        public static implicit operator FinancialGoalResponseModel(CreateFinancialGoalCommand dto)
            => new FinancialGoalResponseModel(null, dto.Title, dto.TargetAmount, dto.Deadline, dto.MonthlyAmount);
    }
}
