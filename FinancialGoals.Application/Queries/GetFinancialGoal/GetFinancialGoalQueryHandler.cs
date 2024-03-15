using FinancialGoals.Application.Models;
using FinancialGoals.Domain.Entities;
using FinancialGoals.Domain.Repositories;
using FinancialGoals.Domain.Results;
using FinancialGoals.Domain.Results.Errors;
using MediatR;

namespace FinancialGoals.Application.Queries.GetFinancialGoal
{
    public class GetFinancialGoalQueryHandler : IRequestHandler<GetFinancialGoalQuery, Result>
    {
        private readonly ITransacationRepository _repository;

        public GetFinancialGoalQueryHandler(ITransacationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(GetFinancialGoalQuery query, CancellationToken cancellationToken)
        {
            var financialGoal = await _repository.GetOne(x => x.Id == query.Id);
            if (financialGoal == null)
            {
                return new Result().Failure(GenericErrors.NotFound("Transaction"));
            }

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
