using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialGoals.Infra.Persistence.Repositories
{
    public class FinancialGoalRepository : BaseRepository<FinancialGoal>, ITransacationRepository
    {
        private readonly FinancialGoalsContext _context;

        public FinancialGoalRepository(FinancialGoalsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllFinancialGoalTransactions(Guid financialGoalId)
            => await _context.Set<Transaction>()
                .Include(x => x.FinancialGoal)
                .Where(x => x.FinancialGoalId == financialGoalId)
                .ToListAsync();
    }
}
