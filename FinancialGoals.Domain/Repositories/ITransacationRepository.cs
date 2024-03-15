using FinancialGoals.Domain.Entities;

namespace FinancialGoals.Domain.Repositories
{
    public interface ITransacationRepository : IBaseRepository<FinancialGoal>
    {
        Task<List<Transaction>> GetAllFinancialGoalTransactions(Guid financialGoalId);
    }
}
