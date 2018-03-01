namespace Castanha.Domain.Customers.Events
{
    using System;
    
    public class ClosedDomainEvent : DomainEvent
    {
        public ClosedDomainEvent(Guid aggregateRootId, int version)
            : base(aggregateRootId, version)
        {
        }
    }
}
