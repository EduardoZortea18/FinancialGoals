using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;

namespace FinancialGoals.Infra.Persistence.Repositories
{
    public class FinancialGoalRepository : BaseRepository<FinancialGoal>, IFinancialGoalRepository
    {
        public FinancialGoalRepository(FinancialGoalsContext context) : base(context)
        {
        }
    }
}
