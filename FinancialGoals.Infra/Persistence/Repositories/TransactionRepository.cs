using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;

namespace FinancialGoals.Infra.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FinancialGoalsContext context) : base(context)
        {
        }
    }
}
