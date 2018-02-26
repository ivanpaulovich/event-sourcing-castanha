namespace Manga.Application.ServiceBus
{
    using Manga.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public interface IPublisher
    {
        Task Publish(IEnumerable<DomainEvent> domainEvents);
    }
}
