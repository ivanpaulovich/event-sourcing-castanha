namespace Castanha.Domain.Customers.Accounts
{
    using System;
    using Castanha.Domain.Customers.Events;
    using Castanha.Domain.ValueObjects;

    public class Credit : Transaction
    {
        public Credit()
        {

        }

        public Credit(Amount amount)
            : base(amount)
        {

        }

        public override string Description
        {
            get
            {
                return "Credit";
            }
        }
    }
}
