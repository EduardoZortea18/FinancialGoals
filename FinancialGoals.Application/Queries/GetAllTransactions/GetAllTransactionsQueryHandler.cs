using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, Result>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Result> Handle(GetAllTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll();

            return new GenericResult<IEnumerable<TransactionResponseModel>>().Ok(transactions.Select(x => new TransactionResponseModel(
                x.Id, x.Amount, x.TransactionType, x.Date, x.FinancialGoalId)));
        }
    }
}
