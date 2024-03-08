using FinancialGoals.Application.Commands.CreateTransaction;
using FinancialGoals.Application.Queries.GetTransaction;
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
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Create([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetTransactionQuery(id));
            return Ok(response);
        }
    }
}
