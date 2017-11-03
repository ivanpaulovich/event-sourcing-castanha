using System;

namespace MyAccountAPI.Domain.Model.Customers.Events
{
    public class InsufficientFundsDomainEvent : DomainEvent
    {
        public InsufficientFundsDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static InsufficientFundsDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException(nameof(aggregateRoot));

            InsufficientFundsDomainEvent domainEvent = new InsufficientFundsDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
