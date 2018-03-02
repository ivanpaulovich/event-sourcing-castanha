using Castanha.Domain;

namespace Castanha.Application
{
    public class TransactionConflictException : CastanhaException
    {
        public IAggregateRoot AggregateRoot { get; private set; }
        public IDomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(IAggregateRoot aggregateRoot, IDomainEvent domainEvent)
        {
            this.AggregateRoot = aggregateRoot;
            this.DomainEvent = domainEvent;
        }
    }
}
