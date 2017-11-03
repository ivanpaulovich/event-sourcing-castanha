using System;

namespace MyAccountAPI.Domain.Model.Customers.Events
{
    public class WithdrewDomainEvent : DomainEvent
    {
        public Guid AccountId { get; private set; }
        public Amount Amount { get; private set; }

        public WithdrewDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static WithdrewDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException(nameof(aggregateRoot));

            WithdrewDomainEvent domainEvent = new WithdrewDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
