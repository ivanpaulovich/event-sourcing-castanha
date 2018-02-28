namespace Castanha.Application.EventHandlers
{
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Events;

    public class CustomerRegisteredEventHandler
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public CustomerRegisteredEventHandler(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public void Handle(CustomerRegisteredDomainEvent domainEvent)
        {
            Customer customer = new Customer();
            customer.Apply(domainEvent);
            customerWriteOnlyRepository.Add(customer).Wait();
        }
    }
}
