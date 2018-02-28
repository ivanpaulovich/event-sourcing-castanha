namespace Castanha.Domain.Customers.Events
{
    using Castanha.Domain.ValueObjects;
    using System;

    public class CustomerRegisteredDomainEvent : DomainEvent
    {
        public Name Name { get; private set; }
        public PIN PIN { get; private set; }
        public Guid AccountId { get; private set; }
        public Amount InitialAmount { get; private set; }

        public CustomerRegisteredDomainEvent(Guid aggregateRootId, int version, 
            DateTime createdDate, Header header, 
            Name name, PIN pin, Guid accountId, Amount initialAmount)
            : base(aggregateRootId, version, createdDate, header)
        {
            this.Name = name;
            this.PIN = pin;
            this.AccountId = accountId;
            this.InitialAmount = initialAmount;
        }

        public static CustomerRegisteredDomainEvent Create(AggregateRoot aggregateRoot,
            Name name, PIN pin, Guid accountId, Amount initialAmount)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException(nameof(aggregateRoot));

            CustomerRegisteredDomainEvent domainEvent = new CustomerRegisteredDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, 
                name, pin, accountId, initialAmount);

            return domainEvent;
        }
    }
}
