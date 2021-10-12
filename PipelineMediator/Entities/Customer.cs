using System;

namespace PipelineMediator.Entities
{
    public sealed class Customer
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }

        public Customer( string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
