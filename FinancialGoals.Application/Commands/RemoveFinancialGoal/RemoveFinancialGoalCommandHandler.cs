using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Commands.RemoveFinancialGoal
{
    public class RemoveFinancialGoalCommandHandler : IRequestHandler<RemoveFinancialGoalCommand, Result>
    {
        private readonly ITransacationRepository _financialGoalRepository;

        public RemoveFinancialGoalCommandHandler(ITransacationRepository financialGoalRepository)
        {
            _financialGoalRepository = financialGoalRepository;
        }

        public async Task<Result> Handle(RemoveFinancialGoalCommand command, CancellationToken cancellationToken)
        {
            var financialGoal = await _financialGoalRepository.GetOne(x => x.Id == command.Id);
            if (financialGoal == null)
            {
                return new Result().Failure(GenericErrors.NotFound("FinancialGoal"));
            }

            financialGoal.Delete();
            await _financialGoalRepository.Update(financialGoal);

            return new GenericResult<FinancialGoalResponseModel>().Ok(CreateResponse(financialGoal));
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
