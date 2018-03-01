namespace Castanha.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using Castanha.Domain.ValueObjects;
    using Castanha.Domain.Customers.Accounts;
    using System.Linq;
    using Castanha.Domain.Customers.Events;

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

        public Customer()
        {
            Register<CustomerRegisteredDomainEvent>(When);

            accounts = new List<Account>();
        }

        public Customer(PIN pin, Name name)
            : this()
        {
            PIN = pin;
            Name = name;
        }

        public virtual void RemoveAccount(Guid accountID)
        {
            Account account = FindAccount(accountID);
            account.Close();
            accounts.Remove(account);
        }

        public virtual void Register(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var domainEvent = new CustomerRegisteredDomainEvent(
                // Customer
                Id, Version, Name, PIN,
                // Account
                account.Id,
                // Transaction
                account.Transactions.First().Id,
                account.Transactions.First().Amount, 
                account.Transactions.First().TransactionDate);

            Raise(domainEvent); 
        }

        protected void When(CustomerRegisteredDomainEvent domainEvent)
        {
            Id = domainEvent.AggregateRootId;
            Name = domainEvent.CustomerName;
            PIN = domainEvent.CustomerPIN;

            Account account = new Account();
            account.When(domainEvent);

            accounts = new List<Account>();
            accounts.Add(account);
        }

        public virtual Account FindAccount(Guid accountID)
        {
            Account account = Accounts.Where(e => e.Id == accountID).FirstOrDefault();
            return account;
        }
    }
}
