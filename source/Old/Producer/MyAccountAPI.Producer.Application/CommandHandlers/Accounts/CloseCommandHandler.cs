namespace MyAccountAPI.Producer.Application.CommandHandlers.Accounts
{
    using MediatR;
    using System;
    using System.Threading.Tasks;
    using MyAccountAPI.Domain.ServiceBus;
    using MyAccountAPI.Producer.Application.Commands.Accounts;
    using MyAccountAPI.Domain.Model.Accounts;
    using MyAccountAPI.Domain.Exceptions;


    public class CloseCommandHandler : IAsyncRequestHandler<CloseCommand>
    {
        private readonly IPublisher bus;
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;

        public CloseCommandHandler(
            IPublisher bus,
            IAccountReadOnlyRepository accountReadOnlyRepository)
        {
            if (bus == null)
                throw new ArgumentNullException(nameof(bus));

            if (accountReadOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountReadOnlyRepository));

            this.bus = bus;
            this.accountReadOnlyRepository = accountReadOnlyRepository;
        }

        public async Task Handle(CloseCommand command)
        {
            Account account = await accountReadOnlyRepository.GetAccount(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            account.Close();

            var domainEvents = account.GetEvents();
            await bus.Publish(domainEvents, command.Header);
        }
    }
}
