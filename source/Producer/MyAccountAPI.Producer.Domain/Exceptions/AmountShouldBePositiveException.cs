namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class AmountShouldBePositiveException : DomainException
    {
        public AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
