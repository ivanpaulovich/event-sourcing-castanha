using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public class Credit : Transaction
    {
        private Credit()
        {

        }

        public static Credit Create(Guid customerId, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Credit credit = new Credit();
            credit.customerId = customerId;
            credit.amount = amount;
            return credit;
        }

        public static Credit Load(Guid id, Guid customerId, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Credit credit = new Credit();
            credit.Id = id;
            credit.customerId = customerId;
            credit.amount = amount;
            return credit;
        }
    }
}
