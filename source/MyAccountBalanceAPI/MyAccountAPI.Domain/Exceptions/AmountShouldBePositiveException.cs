using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AmountShouldBePositiveException : DomainException
    {
        public AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
