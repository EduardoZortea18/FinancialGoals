using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Enums;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransacationRepository _financialGoalRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, ITransacationRepository financialGoalRepository)
        {
            _transactionRepository = transactionRepository;
            _financialGoalRepository = financialGoalRepository;

        }

        public async Task<Result> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = new Transaction(command.Amount, command.TransactionType, command.Date, command.FinancialGoalId);
            var financialGoal = await _financialGoalRepository.GetOne(x => x.Id == command.FinancialGoalId);

            var amount = transaction.TransactionType == TransactionType.Deposit
                ? transaction.Amount
                : -transaction.Amount;

            if (!(financialGoal.ActualAmount + amount >= 0))
            {
                return new Result().Failure(GenericErrors.ValidationProblem("Your operation is not valid"));
            }

            financialGoal.UpdateAmount(amount);
            await _financialGoalRepository.Update(financialGoal);
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
