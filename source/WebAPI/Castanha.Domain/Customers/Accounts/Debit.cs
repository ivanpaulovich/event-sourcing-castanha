namespace Castanha.Domain.Customers.Accounts
{
    using Castanha.Domain.ValueObjects;

    public class Debit : Transaction
    {
        public Debit()
        {

        }

        public Debit(Amount amount)
            :base(amount)
        {

        }

        public override string Description
        {
            get
            {
                return "Debit";
            }
        }
    }
}
