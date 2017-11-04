using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts.Events
{
    public class WithdrewDomainEvent : DomainEvent
    {
        public Guid TransactionId { get; private set; }
        public Amount Amount { get; private set; }

        public WithdrewDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header, Guid transactionId, Amount amount)
            : base(aggregateRootId, version, createdDate, header)
        {
            this.TransactionId = transactionId;
            this.Amount = amount;
        }

        public static WithdrewDomainEvent Create(AggregateRoot aggregateRoot, Guid transactionId, Amount amount)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException(nameof(aggregateRoot));

            WithdrewDomainEvent domainEvent = new WithdrewDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, transactionId, amount);

            return domainEvent;
        }
    }
}
