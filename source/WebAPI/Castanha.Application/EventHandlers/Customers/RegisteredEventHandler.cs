namespace Castanha.Application.EventHandlers
{
    using Castanha.Application.Repositories;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Events;

    public class RegisteredEventHandler : IEventHandler<RegisteredDomainEvent>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public RegisteredEventHandler(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public void Handle(RegisteredDomainEvent domainEvent)
        {
            Customer customer = new Customer();
            customer.Apply(domainEvent);
            customerWriteOnlyRepository.Add(customer).Wait();
        }
    }
}
