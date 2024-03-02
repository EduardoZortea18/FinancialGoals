using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Commands.RemoveTransaction
{
    public class RemoveTransactionCommandHandler: IRequestHandler<RemoveTransactionCommand, Result>
    {
        private readonly ITransactionRepository _transactionRepository;

        public RemoveTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Result> Handle(RemoveTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetOne(x => x.Id == command.Id);
            if (transaction == null)
            {
                return new Result().Failure(GenericErrors.NotFound("Transaction"));
            }

            transaction.Delete();
            await _transactionRepository.Update(transaction);

            return new GenericResult<TransactionResponseModel>().Ok(CreateResponse(transaction));
        }

        private TransactionResponseModel CreateResponse(Transaction transaction)
           => new TransactionResponseModel(
               transaction.Id,
               transaction.Amount,
               transaction.TransactionType,
               transaction.Date,
               transaction.FinancialGoalId);
    }
}
