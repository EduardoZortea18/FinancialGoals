using FinancialGoals.Domain.Enums;

namespace FinancialGoals.Domain.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public FinancialGoal(
            string title,
            decimal targetAmount,
            DateTime deadline,
            decimal monthlyAmount,
            FinancialGoalStatus status)
        {
            Title = title;
            TargetAmount = targetAmount;
            Deadline = deadline;
            MonthlyAmount = monthlyAmount;
            Status = status;
        }

        public FinancialGoal()
        {
        }

        public string Title { get; private set; }
        public decimal TargetAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public decimal MonthlyAmount { get; private set; }
        public FinancialGoalStatus Status { get; private set; }
        public decimal ActualAmount { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public void Update(
            string title,
            decimal targetAmount,
            DateTime deadline,
            decimal monthlyAmount,
            FinancialGoalStatus status)
        {
            Title = title;
            TargetAmount = targetAmount;
            Deadline = deadline;
            MonthlyAmount = monthlyAmount;
            Status = status;
        }

        public void UpdateAmount(decimal amount)
        {
            ActualAmount += amount;
        }
    }
}
