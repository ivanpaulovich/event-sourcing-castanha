using MyAccountAPI.Domain.Model;

namespace MyAccountAPI.Domain.Exceptions
{
    public class TransactionConflictException : MyAccountAPIException
    {
        public AggregateRoot AggregateRoot { get; private set; }
        public DomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(AggregateRoot aggregateRoot, DomainEvent domainEvent)
        {
            this.AggregateRoot = aggregateRoot;
            this.DomainEvent = domainEvent;
        }
    }
}
