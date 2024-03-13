using FinancialGoals.Application.Commands.CreateTransaction;
using FinancialGoals.Application.Commands.RemoveFinancialGoal;
using FinancialGoals.Application.Commands.RemoveTransaction;
using FinancialGoals.Application.Queries.GetAllTransactions;
using FinancialGoals.Application.Queries.GetTransaction;
using FinancialGoals.Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoals.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionCommand command)
        {
            var response = await _mediator.Send(command);
            return Created(nameof(GetOneById), response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetTransactionQuery(id));
            if (response.HasError)
            {
                return NotFound(response.Error!.Message);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new RemoveTransactionCommand(id));

            if (response.HasError)
            {
                return NotFound(response.Error!.Message);
            }

            return NoContent();
        }
    }
}
