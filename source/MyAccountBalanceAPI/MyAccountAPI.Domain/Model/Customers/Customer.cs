using MyAccountAPI.Domain.Model.Customers.Events;
using System.Collections.Generic;
using System;

namespace MyAccountAPI.Domain.Model.Customers
{
    public class Customer : AggregateRoot
    {
        private Name name;
        private PIN pin;
        private List<Account> accounts;

        public IReadOnlyCollection<Account> GetAccounts()
        {
            return accounts;
        }

        public Name GetName()
        {
            return name;
        }

        public PIN GetPIN()
        {
            return pin;
        }

        private Customer()
        {
            Register<RegisteredDomainEvent>(When);
            Register<DepositedDomainEvent>(When);
            Register<WithdrewDomainEvent>(When);
            Register<ClosedDomainEvent>(When);
        }

        public static Customer Create(PIN pin, Name name)
        {
            if (pin == null)
                throw new ArgumentNullException(nameof(pin));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Customer customer = new Customer();
            customer.pin = pin;
            customer.name = name;
            return customer;
        }

        public void Register(Account account)
        {
            Raise(RegisteredDomainEvent.Create(
                this, this.GetName(), this.GetPIN(), account.Id, account.Amount));
        }

        public void Deposit(Guid accountId, Amount amount)
        {
            Raise(DepositedDomainEvent.Create(this));
        }

        public void Withdraw(Guid accountId, Amount amount)
        {
            Raise(WithdrewDomainEvent.Create(this));
        }

        public void Close(Guid accountId)
        {
            Raise(ClosedDomainEvent.Create(this));
        }

        protected void When(RegisteredDomainEvent domainEvent)
        {
            Id = domainEvent.AggregateRootId;
            name = domainEvent.Name;
            pin = domainEvent.PIN;

            accounts = new List<Account>();

            Account account = Account.Create(domainEvent.AccountId, domainEvent.Amount);
            accounts.Add(account);
        }

        protected void When(DepositedDomainEvent domainEvent)
        {
            Account account = accounts.Find(e => e.Id == domainEvent.AccountId);
            account.Deposit(domainEvent.Amount);
        }

        protected void When(WithdrewDomainEvent domainEvent)
        {
            Account account = accounts.Find(e => e.Id == domainEvent.AccountId);
            account.Withdraw(domainEvent.Amount);
        }

        protected void When(ClosedDomainEvent domainEvent)
        {
            Account account = accounts.Find(e => e.Id == domainEvent.AccountId);
            accounts.Remove(account);
        }
    }
}
