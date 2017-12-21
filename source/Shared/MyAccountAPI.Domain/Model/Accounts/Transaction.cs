using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public class Transaction : Entity
    {
        protected Guid customerId;
        protected Amount amount;

        public Guid GetCustomerId()
        {
            return customerId;
        }

        public Amount GetAmount()
        {
            return amount;
        }

        protected Transaction()
        {

        }
    }
}
