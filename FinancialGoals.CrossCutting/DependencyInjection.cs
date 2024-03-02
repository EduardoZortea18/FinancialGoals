using FinancialGoals.Application.Commands.CreateTransaction;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Infra;
using FinancialGoals.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialGoals.CrossCutting
{
    public static class DependencyInjection
    {
        public static void ConfigureInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddData(services, configuration);
            AddApplication(services);
        }

        public static void AddData(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            IServiceCollection serviceCollection = services.AddDbContext<FinancialGoalsContext>(opts => opts.UseNpgsql(connectionString));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

        public static void AddApplication(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTransactionCommand).Assembly));
        }
    }
}
