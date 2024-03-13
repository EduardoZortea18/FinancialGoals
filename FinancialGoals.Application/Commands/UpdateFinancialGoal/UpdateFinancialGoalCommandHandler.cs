using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoals.Application.Commands.UpdateFinancialGoal
{
    public class UpdateFinancialGoalCommandHandler : IRequestHandler<UpdateFinancialGoalCommand, Result>
    {
        private readonly IFinancialGoalRepository _financialGoalRepository;

        public UpdateFinancialGoalCommandHandler(IFinancialGoalRepository financialGoalRepository)
        {
            _financialGoalRepository = financialGoalRepository;
        }

        public async Task<Result> Handle(UpdateFinancialGoalCommand command, CancellationToken cancellationToken)
        {
            var financialGoal = await _financialGoalRepository.GetOne(x => x.Id == command.Id);

            if (financialGoal == null)
            {
                return new Result().Failure(GenericErrors.NotFound("FinancialGoal"));
            }

            financialGoal.Update(command.title, command.targetAmount, command.deadline, command.monthlyAmount);
            await _financialGoalRepository.Update(financialGoal);

            return new GenericResult<FinancialGoalResponseModel>().Ok(CreateResponse(financialGoal));
        }

        private FinancialGoalResponseModel CreateResponse(FinancialGoal financialGoal)
          => new FinancialGoalResponseModel(
              financialGoal.Id,
              financialGoal.Title,
              financialGoal.TargetAmount,
              financialGoal.Deadline,
              financialGoal.MonthlyAmount);
    }
}
