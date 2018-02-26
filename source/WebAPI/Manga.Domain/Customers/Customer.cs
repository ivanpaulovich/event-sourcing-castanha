namespace Manga.Domain.Customers
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Customers.Accounts;
    using System.Linq;
    using Manga.Domain.Customers.Events;

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

        protected Customer()
        {
            Register<RegisteredDomainEvent>(When);

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

            Raise(RegisteredDomainEvent.Create(
                this, this.Name, this.PIN,
                account.Id, account.CurrentBalance));
        }

        protected void When(RegisteredDomainEvent domainEvent)
        {
            if (domainEvent == null)
                throw new ArgumentNullException(nameof(domainEvent));

            Id = domainEvent.AggregateRootId;
            Name = domainEvent.Name;
            PIN = domainEvent.PIN;

            Account account = new Account();
            Credit credit = new Credit(domainEvent.InitialAmount);
            account.Deposit(credit);

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
