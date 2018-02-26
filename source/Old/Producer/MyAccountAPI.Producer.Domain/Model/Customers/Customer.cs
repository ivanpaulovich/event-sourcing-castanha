namespace MyAccountAPI.Domain.Model.Customers
{
    using MyAccountAPI.Domain.Model.Customers.Events;
    using System.Collections.Generic;
    using System;
    using MyAccountAPI.Domain.Model.ValueObjects;
    using MyAccountAPI.Domain.Model.Accounts;
    using System.Linq;

    public class Customer : AggregateRoot
    {
        public Name Name { get; private set; }
        public PIN PIN { get; private set; }

        private List<Account> accounts;
        public IReadOnlyCollection<Account> Accounts
        {
            get
            {
                return accounts.AsReadOnly();
            }
            private set
            {
                accounts = value.ToList();
            }
        }

        private Customer()
        {
            Register<RegisteredDomainEvent>(When);            
        }

        public static Customer Create()
        {
            Customer customer = new Customer();
            return customer;
        }

        public static Customer Create(PIN pin, Name name)
        {
            if (pin == null)
                throw new ArgumentNullException(nameof(pin));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Customer customer = new Customer();
            customer.PIN = pin;
            customer.Name = name;
            return customer;
        }

        public void Register(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            Raise(RegisteredDomainEvent.Create(
                this, this.Name, this.PIN, 
                account.Id, account.GetCurrentBalance()));
        }

        protected void When(RegisteredDomainEvent domainEvent)
        {
            if (domainEvent == null)
                throw new ArgumentNullException(nameof(domainEvent));

            Id = domainEvent.AggregateRootId;
            Name = domainEvent.Name;
            PIN = domainEvent.PIN;

            Account account = Account.Load(domainEvent.AccountId, domainEvent.InitialAmount);

            accounts = new List<Account>();
            accounts.Add(account);
        }
    }
}
