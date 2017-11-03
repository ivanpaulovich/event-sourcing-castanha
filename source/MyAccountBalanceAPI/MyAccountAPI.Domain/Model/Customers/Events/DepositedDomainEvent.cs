using System;

namespace MyAccountAPI.Domain.Model.Customers.Events
{
    public class DepositedDomainEvent : DomainEvent
    {
        public DepositedDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static DepositedDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException(nameof(aggregateRoot));

            DepositedDomainEvent domainEvent = new DepositedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
