using MediatR;
using PipelineMediator.Entities;

namespace PipelineMediator.Commands
{
    public sealed class AddCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
