using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Enums;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateFinancialGoal
{
    public sealed record CreateFinancialGoalCommand(
        string Title,
        decimal TargetAmount,
        DateTime Deadline,
        decimal MonthlyAmount,
        FinancialGoalStatus Status,
        decimal ActualAmount = 0) : IRequest<Result>
    {
        public static implicit operator FinancialGoal(CreateFinancialGoalCommand command)
            => new FinancialGoal(command.Title, command.TargetAmount, command.Deadline, command.MonthlyAmount, command.Status);

        public static implicit operator FinancialGoalResponseModel(CreateFinancialGoalCommand command)
            => new FinancialGoalResponseModel(null, command.Title, command.TargetAmount, command.Deadline, command.MonthlyAmount, command.Status, command.ActualAmount);
    }
}
