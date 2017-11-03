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
            if (initialAmount == null)
                throw new ArgumentNullException(nameof(initialAmount));

            Account account = new Account();
            account.amount = initialAmount;
            return account;
        }

        public static Account Create(Guid id, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Account account = new Account();
            account.Id = id;
            account.amount = amount;
            return account;
        }

        public void Deposit(Amount depositedAmount)
        {
            if (depositedAmount == null)
                throw new ArgumentNullException(nameof(depositedAmount));

            amount = Amount + depositedAmount;
        }

        public void Withdraw(Amount withdrewAmount)
        {
            if (withdrewAmount == null)
                throw new ArgumentNullException(nameof(withdrewAmount));

            amount = Amount - withdrewAmount;
        }
    }
}
