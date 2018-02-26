namespace MyAccountAPI.Domain.Exceptions
{
    public class DomainException : MyAccountAPIException
    {
        public string BusinessMessage { get; set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
