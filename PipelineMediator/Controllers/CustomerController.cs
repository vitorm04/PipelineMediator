using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipelineMediator.Commands;
using System.Threading.Tasks;

namespace PipelineMediator.Controllers
{
    [Route("api/customers")]
    public sealed class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody] AddCustomerCommand command)
        {
            var output = await _mediator.Send(command);
            return Created(uri: string.Empty, output);
        }
    }
}
