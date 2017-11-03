using MyAccountAPI.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAccountAPI.Domain.ServiceBus
{
    public interface IPublisher : IDisposable
    {
        Task Publish(DomainEvent domainEvent);
        Task Publish(IEnumerable<DomainEvent> domainEvents, Header header);
    }
}
