﻿namespace Castanha.Application.EventHandlers
{
    using Castanha.Application.Repositories;
    using Castanha.Domain.Accounts;
    using Castanha.Domain.Accounts.Events;

    public class OpenedEventHandler : IEventHandler<OpenedDomainEvent>
    {
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;

        public OpenedEventHandler(
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public void Handle(OpenedDomainEvent domainEvent)
        {
            Account account = new Account();
            account.Apply(domainEvent);
            accountWriteOnlyRepository.Add(domainEvent).Wait();
        }
    }
}
