using MediatR;
using PipelineMediator.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PipelineMediator.Commands
{
    public sealed class CustomerHandler : IRequestHandler<AddCustomerCommand, Customer>
    {
        public Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new(request.Name, request.Email);
            //Some logic to add in database
            return Task.FromResult(customer);
        }
    }
}
