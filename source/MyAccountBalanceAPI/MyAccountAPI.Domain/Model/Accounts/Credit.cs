using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public class Credit : Transaction
    {
        private Credit()
        {

        }

        private Credit(Amount amount)
            : base()
        {

        }

        public static Credit Create(Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Credit credit = new Credit();
            credit.amount = amount;
            return credit;
        }

        public static Credit Load(Guid id, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Credit credit = new Credit();
            credit.Id = id;
            credit.amount = amount;
            return credit;
        }
    }
}
