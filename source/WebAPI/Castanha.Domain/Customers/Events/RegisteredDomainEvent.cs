namespace Castanha.Domain.Customers.Events
{
    using Castanha.Domain.ValueObjects;
    using System;

    /// <summary>
    /// Events should be immutable and serializable
    /// </summary>
    public class RegisteredDomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }
        public Name CustomerName { get; private set; }
        public PIN CustomerPIN { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Amount TransactionAmount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public RegisteredDomainEvent(
            Guid aggregateRootId, 
            int version,
            Name customerName,
            PIN customerPIN, 
            Guid accountId,
            Guid transactionId,
            Amount transactionAmount,
            DateTime transactionDate)
        {
            this.AggregateRootId = aggregateRootId;
            this.Version = version;
            this.CustomerName = customerName;
            this.CustomerPIN = customerPIN;
            this.AccountId = accountId;
            this.TransactionId = transactionId;
            this.TransactionAmount = transactionAmount;
            this.TransactionDate = transactionDate;
        }
    }
}
