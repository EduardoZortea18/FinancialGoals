namespace FinancialGoals.Domain.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public FinancialGoal(string title, decimal targetAmount, DateTime deadline, decimal monthlyAmount)
        {
            Title = title;
            TargetAmount = targetAmount;
            Deadline = deadline;
            MonthlyAmount = monthlyAmount;
        }

        public FinancialGoal()
        {
        }

        public string Title { get; private set; }
        public decimal TargetAmount { get; private set; }
        public DateTime Deadline { get; private set; }
        public decimal MonthlyAmount { get; private set; }
        public List<Transaction> Transactions { get; private set; }
    }
}
