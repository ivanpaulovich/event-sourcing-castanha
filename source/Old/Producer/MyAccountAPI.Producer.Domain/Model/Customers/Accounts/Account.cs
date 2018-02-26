namespace MyAccountAPI.Domain.Model.Accounts
{
    using MyAccountAPI.Domain.Exceptions;
    using MyAccountAPI.Domain.Model.Accounts.Events;
    using MyAccountAPI.Domain.Model.Customers.Events;
    using MyAccountAPI.Domain.Model.ValueObjects;
    using System;
    using System.Collections.Generic;

    public class Account : Entity, IAggregate
    {
        public Amount CurrentBalance { get; private set; }

        public Account()
        {
            transactions = new List<Transaction>();
            CurrentBalance = new Amount(0);
        }

        private List<Transaction> transactions;
        public IReadOnlyCollection<Transaction> Transactions
        {
            get
            {
                return transactions.AsReadOnly();
            }
            private set
            {
                transactions = value.ToList();
            }
        }

        public void Deposit(Credit transaction)
        {
            transactions.Add(transaction);

            CurrentBalance = CurrentBalance + transaction.Amount;
        }

        public void Withdraw(Debit transaction)
        {
            if (CurrentBalance < transaction.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {transaction.Amount}.");

            transactions.Add(transaction);

            CurrentBalance = CurrentBalance - transaction.Amount;
        }

        public void Close()
        {
            if (CurrentBalance > new Amount(0))
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");
        }
    }
}
