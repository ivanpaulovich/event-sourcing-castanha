using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public class Debit : Transaction
    {
        private Debit()
        {

        }

        private Debit(Amount amount)
            : base()
        {

        }

        public static Debit Create(Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Debit Debit = new Debit();
            Debit.amount = amount;
            return Debit;
        }

        public static Debit Load(Guid id, Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Debit Debit = new Debit();
            Debit.Id = id;
            Debit.amount = amount;
            return Debit;
        }
    }
}
