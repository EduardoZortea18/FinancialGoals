using FinancialGoals.Domain.Enums;

namespace FinancialGoals.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction(decimal amount, TransactionType transactionType, DateTime date, Guid financialGoalId)
        {
            Amount = amount;
            TransactionType = transactionType;
            Date = date;
            FinancialGoalId = financialGoalId;
        }

        public decimal Amount { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public DateTime Date { get; private set; }
        public Guid FinancialGoalId { get; private set; }
        public FinancialGoal FinancialGoal { get; private set; }
    }
}
