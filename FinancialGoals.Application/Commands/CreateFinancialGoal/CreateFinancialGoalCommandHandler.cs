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
        private readonly IFinancialGoalRepository _repository;

        public CreateFinancialGoalCommandHandler(IFinancialGoalRepository repository)
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

            await _repository.Create(command);

            return new GenericResult<FinancialGoalResponseModel>().Ok(command);
        }
    }
}
