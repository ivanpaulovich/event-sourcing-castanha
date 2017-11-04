using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class InsuficientFundsException : DomainException
    {
        public InsuficientFundsException(string message)
            : base(message)
        { }
    }
}
