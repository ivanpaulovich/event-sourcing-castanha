namespace Castanha.Domain.Customers.Events
{
    using Castanha.Domain.ValueObjects;
    using System;

    public class CustomerRegisteredDomainEvent : DomainEvent
    {
        public Name CustomerName { get; private set; }
        public PIN CustomerPIN { get; private set; }
        public Guid AccountId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Amount TransactionAmount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public CustomerRegisteredDomainEvent(
            Guid aggregateRootId, 
            int version,
            Name customerName,
            PIN customerPIN, 
            Guid accountId,
            Guid transactionId,
            Amount transactionAmount,
            DateTime transactionDate)
            : base(aggregateRootId, version)
        {
            this.CustomerName = customerName;
            this.CustomerPIN = customerPIN;
            this.AccountId = accountId;
            this.TransactionId = transactionId;
            this.TransactionAmount = transactionAmount;
            this.TransactionDate = transactionDate;
        }
    }
}
