using MediatR;
using System;
using System.Threading.Tasks;
using MyAccountAPI.Domain.ServiceBus;
using MyAccountAPI.Producer.Application.Commands.Accounts;
using MyAccountAPI.Domain.Model.Customers;

namespace MyAccountAPI.Producer.Application.CommandHandlers.Accounts
{
    public class WithdrawCommandHandler : IAsyncRequestHandler<WithdrawCommand>
    {
        private readonly IPublisher bus;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public WithdrawCommandHandler(
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

        public async Task Handle(WithdrawCommand command)
        {
            Customer customer = await customerReadOnlyRepository.GetCustomer(command.CustomerId);
            customer.Withdraw(
                command.AccountId, 
                Amount.Create(command.Amount));

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents, command.Header);
        }
    }
}
