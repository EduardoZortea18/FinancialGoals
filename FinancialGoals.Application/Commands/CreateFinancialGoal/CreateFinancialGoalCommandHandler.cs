using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Commands.CreateFinancialGoal
{
    public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, Result>
    {
        private readonly ITransacationRepository _repository;

        public CreateFinancialGoalCommandHandler(ITransacationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateFinancialGoalCommand command, CancellationToken cancellationToken)
        {
            var alreadyExists = await _repository.Exists(x => x.Deadline == command.Deadline
                && x.Title == command.Title);

            if (alreadyExists)
            {
                return new Result().Failure(GenericErrors.AlreadyExists("FinancialGoal"));
            }

            var entity = await _repository.Create(command);
            return new GenericResult<FinancialGoalResponseModel>().Ok(CreateResponse(entity));
        }

        private FinancialGoalResponseModel CreateResponse(FinancialGoal financialGoal)
        => new FinancialGoalResponseModel(
            financialGoal.Id,
            financialGoal.Title,
            financialGoal.TargetAmount,
            financialGoal.Deadline,
            financialGoal.MonthlyAmount,
            financialGoal.Status,
            financialGoal.ActualAmount);
    }
}
