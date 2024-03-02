using FinancialGoals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoals.Infra.Configuration
{
    public class FinancialGoalConfiguration : BaseEntityConfiguration<FinancialGoal>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FinancialGoal> builder)
        {
            builder.Property(x => x.TargetAmount)
                .HasPrecision(2);

            builder.Property(x => x.Title)
                .HasMaxLength(30);

            builder.Property(x => x.Deadline);

            builder.Property(x => x.MonthlyAmount)
                .IsRequired(false);

            builder
              .HasMany(x => x.Transactions)
              .WithOne(it => it.FinancialGoal)
              .HasForeignKey(it => it.FinancialGoalId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
