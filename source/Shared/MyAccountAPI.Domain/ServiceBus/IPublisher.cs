namespace MyAccountAPI.Domain.ServiceBus
{
    using MyAccountAPI.Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPublisher : IDisposable
    {
        Task Publish(DomainEvent domainEvent);
        Task Publish(IEnumerable<DomainEvent> domainEvents, Header header);
    }
}
