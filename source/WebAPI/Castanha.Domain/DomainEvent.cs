namespace Castanha.Domain
{
    using System;

    public class DomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }

        protected DomainEvent(Guid aggregateRootId, int version)
        {
            this.AggregateRootId = aggregateRootId;
            this.Version = version;
        }
    }
}
