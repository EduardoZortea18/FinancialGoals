using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, Result>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Result> Handle(GetTransactionQuery query, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetOne(x => x.Id == query.Id);
            if (transaction == null)
            {
                return new Result().Failure(GenericErrors.NotFound("Transaction"));
            }

            var responseModel = new TransactionResponseModel(
                transaction.Id, transaction.Amount, transaction.TransactionType, transaction.Date, transaction.FinancialGoalId);

            return new GenericResult<TransactionResponseModel>().Ok(responseModel);
        }
    }
}
