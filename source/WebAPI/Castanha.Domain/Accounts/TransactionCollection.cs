namespace Castanha.Domain.Accounts
{
    using Castanha.Domain.ValueObjects;
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionCollection
    {
        private List<Transaction> items;
        public IReadOnlyCollection<Transaction> Items
        {
            get
            {
                return items.AsReadOnly();
            }
            private set
            {
                items = value.ToList();
            }
        }

        public TransactionCollection()
        {
            items = new List<Transaction>();
        }

        internal Amount GetCurrentBalance()
        {
            Amount totalAmount = new Amount(0);

            foreach (var item in Items)
            {
                totalAmount += item.Amount;
            }

            return totalAmount;
        }

        internal void Add(Transaction transaction)
        {
            items.Add(transaction);
        }
    }
}
