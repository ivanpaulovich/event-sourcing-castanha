﻿namespace Castanha.Domain.Accounts
{
    using Castanha.Domain.Accounts.Events;
    using Castanha.Domain.Customers.Events;
    using Castanha.Domain.ValueObjects;

    public class Account : AggregateRoot
    {
        public TransactionCollection Transactions { get; private set; }

        public Account()
        {
            Register<DepositedDomainEvent>(When);
            Register<WithdrewDomainEvent>(When);
            Register<RegisteredDomainEvent>(When);
            Register<ClosedDomainEvent>(When);

            Transactions = new TransactionCollection();
        }

        public void Deposit(Credit credit)
        {
            var domainEvent = new DepositedDomainEvent(
                    Id,
                    Version,
                    credit.Id,
                    credit.Amount
                );

            Raise(domainEvent);
        }

        public void Withdraw(Debit debit)
        {
            if (Transactions.GetCurrentBalance() < debit.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {debit.Amount}.");

            var domainEvent = new WithdrewDomainEvent(
                    Id,
                    Version,
                    debit.Id,
                    debit.Amount
                );

            Raise(domainEvent);
        }

        public void Close()
        {
            if (Transactions.GetCurrentBalance() > new Amount(0))
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");

            var domainEvent = new ClosedDomainEvent(
                    Id,
                    Version
                );

            Raise(domainEvent);
        }

        protected void When(RegisteredDomainEvent domainEvent)
        {
            //
            // Open an Account
            //

            Id = domainEvent.AccountId;
            Transactions = new TransactionCollection();

            Transaction credit = new Credit(
                domainEvent.TransactionId,
                domainEvent.TransactionAmount,
                domainEvent.TransactionDate);

            Transactions.Add(credit);
        }

        public Amount GetCurrentBalance()
        {
            return Transactions.GetCurrentBalance();
        }

        protected void When(DepositedDomainEvent domainEvent)
        {
            Transaction credit = new Credit(domainEvent.TransactionAmount);
            Transactions.Add(credit);
        }

        protected void When(WithdrewDomainEvent domainEvent)
        {
            Transaction debit = new Debit(domainEvent.TransactionAmount);
            Transactions.Add(debit);
        }

        protected void When(ClosedDomainEvent domainEvent)
        {

        }
    }
}