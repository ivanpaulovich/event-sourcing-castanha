namespace Castanha.Application.EventHandlers
{
    using Castanha.Application.Repositories;
    using Castanha.Domain.Accounts;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Events;

    public class CustomerRegisteredEventHandler : IEventHandler<RegisteredDomainEvent>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public CustomerRegisteredEventHandler(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(RegisteredDomainEvent domainEvent)
        {
            Customer customer = new Customer();
            customer.Apply(domainEvent);
            customerWriteOnlyRepository.Add(customer).Wait();

            Account account = new Account();
            account.Apply(domainEvent);
            accountWriteOnlyRepository.Add(account).Wait();
        }
    }
}
