using MediatR;
using System;
using System.Threading.Tasks;
using MyAccountAPI.Domain.ServiceBus;
using MyAccountAPI.Producer.Application.Commands.Accounts;
using MyAccountAPI.Domain.Model.Customers;

namespace MyAccountAPI.Producer.Application.CommandHandlers.Accounts
{
    public class CloseCommandHandler : IAsyncRequestHandler<CloseCommand>
    {
        private readonly IPublisher bus;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public CloseCommandHandler(
            IPublisher bus,
            ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            if (bus == null)
                throw new ArgumentNullException(nameof(bus));

            if (customerReadOnlyRepository == null)
                throw new ArgumentNullException(nameof(customerReadOnlyRepository));

            this.bus = bus;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public async Task Handle(CloseCommand command)
        {
            Customer customer = await customerReadOnlyRepository.GetCustomer(command.CustomerId);
            customer.Close(command.AccountId);

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents, command.Header);
        }
    }
}
