namespace Castanha.Infrastructure.Dispatcher
{
    using Castanha.Application;
    using System;
    using Castanha.Domain;

    public class Dispatcher : IDispatcher
    {
        public void Send(IDomainEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
