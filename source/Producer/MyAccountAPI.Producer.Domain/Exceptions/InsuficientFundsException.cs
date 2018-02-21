namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class InsuficientFundsException : DomainException
    {
        public InsuficientFundsException(string message)
            : base(message)
        { }
    }
}
