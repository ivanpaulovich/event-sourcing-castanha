namespace MyAccountAPI.Producer.Application.UseCases.Register
{
    using MyAccountAPI.Producer.Application.Responses;
    public class RegisterResponse
    {
        public CustomerResponse Customer { get; private set; }
        public AccountResponse Account { get; private set; }

        public RegisterResponse()
        {

        }

        public RegisterResponse(CustomerResponse customer, AccountResponse account)
        {
            Customer = customer;
            Account = account;
        }
    }
}
