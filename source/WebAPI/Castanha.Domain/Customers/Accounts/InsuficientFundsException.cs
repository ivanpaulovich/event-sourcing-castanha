namespace Castanha.Domain.Customers.Accounts
{
    public class InsuficientFundsException : DomainException
    {
        internal InsuficientFundsException(string message)
            : base(message)
        { }
    }
}
