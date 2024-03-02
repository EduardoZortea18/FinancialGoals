using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialGoals.Infra
{
    public class FinancialGoalsContext : DbContext
    {
        public FinancialGoalsContext(DbContextOptions<FinancialGoalsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
