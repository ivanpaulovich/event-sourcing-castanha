using MyAccountAPI.Domain.Model.ValueObjects;
using System;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public class Transaction : Entity
    {
        protected Amount amount;

        public Amount GetAmount()
        {
            return amount;
        }

        protected Transaction()
        {

        }
    }
}
