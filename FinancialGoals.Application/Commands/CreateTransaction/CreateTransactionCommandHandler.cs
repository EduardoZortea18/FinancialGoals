using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result>
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Result> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = new Transaction(command.Amount, command.TransactionType, command.Date, command.FinancialGoalId);
            await _transactionRepository.Create(transaction);
            return new GenericResult<TransactionResponseModel>(CreateResponse(transaction), false, GenericErrors.NoError());
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
