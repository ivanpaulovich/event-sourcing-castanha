using System;

namespace MyAccountAPI.Domain.Model.Customers
{
    public class Account : Entity
    {
        private Amount amount;

        public Amount Amount
        {
            get
            {
                return amount;
            }
        }

        private Account()
        {

        }

        public static Account Create(Amount initialAmount)
        {
            Account account = new Account();
            account.amount = initialAmount;
            return account;
        }

        public static Account Create(Guid id, Amount amount)
        {
            Account account = new Account();
            account.Id = id;
            account.amount = amount;
            return account;
        }
    }
}
