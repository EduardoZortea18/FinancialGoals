using FinancialGoals.Application.Commands.CreateFinancialGoal;
using FinancialGoals.Application.Commands.RemoveFinancialGoal;
using FinancialGoals.Application.Commands.UpdateFinancialGoal;
using FinancialGoals.Application.Queries.GetAllFinancialGoals;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllFinancialGoalsQuery());
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateFinancialGoalCommand command, [FromRoute] Guid id)
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new RemoveFinancialGoalCommand(id));

            if (response.HasError)
            {
                return NotFound(response.Error!.Message);
            }

            return NoContent();
        }
    }
}
