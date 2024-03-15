using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using MediatR;
using System.Text;

namespace FinancialGoals.Application.Queries.GetFinancialGoalReport
{
    public class GetFinancialGoalReportQueryHandler : IRequestHandler<GetFinancialGoalReportQuery, GenericResult<string>>
    {
        private readonly ITransacationRepository _transactionRepository;

        public GetFinancialGoalReportQueryHandler(ITransacationRepository financialGoalRepository)
        {
            _transactionRepository = financialGoalRepository;
        }

        public async Task<GenericResult<string>> Handle(GetFinancialGoalReportQuery query, CancellationToken cancellationToken)
        {
            var financialGoalTransactions = await _transactionRepository.GetAllFinancialGoalTransactions(query.FinancialGoalId);

            var sb = new StringBuilder();

            sb.AppendLine("Amount;TransactionType;Date;FinancialGoal");

            foreach (var item in financialGoalTransactions)
            {
                sb.AppendLine($"{item.Amount};{item.TransactionType};{item.Date};{item.FinancialGoal.Title}");
            }

            return new GenericResult<string>().Ok(sb.ToString());
        }
    }
}
