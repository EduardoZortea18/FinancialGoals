using FinancialGoals.Application.Commands.CreateFinancialGoal;
using FinancialGoals.Application.Queries.GetFinancialGoal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoals.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialGoalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialGoalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFinancialGoalCommand command)
        {
            var response = await _mediator.Send(command);
            return Created(nameof(GetOneById), response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetFinancialGoalQuery(id));
            return Ok(response);
        }
    }
}
