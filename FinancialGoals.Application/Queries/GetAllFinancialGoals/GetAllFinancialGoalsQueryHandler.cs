using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using MediatR;

namespace FinancialGoals.Application.Queries.GetAllFinancialGoals
{
    public class GetAllFinancialGoalsQueryHandler : IRequestHandler<GetAllFinancialGoalsQuery, Result>
    {
        private readonly ITransacationRepository _financialGoalRepository;

        public GetAllFinancialGoalsQueryHandler(ITransacationRepository financialGoalRepository)
        {
            _financialGoalRepository = financialGoalRepository;
        }

        public async Task<Result> Handle(GetAllFinancialGoalsQuery query, CancellationToken cancellationToken)
        {
            var financialGoals = await _financialGoalRepository.GetAll();

            return new GenericResult<IEnumerable<FinancialGoalResponseModel>>().Ok(financialGoals.Select(x => CreateResponse(x)));
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
