namespace Castanha.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Castanha.Domain.Customers;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.Responses;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Application.ServiceBus;

    public class RegisterInteractor : IInputBoundary<RegisterCommand>
    {
        private readonly IPublisher bus;
        private readonly IOutputBoundary<RegisterResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public RegisterInteractor(
            IPublisher bus,
            IOutputBoundary<RegisterResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(RegisterCommand message)
        {
            Customer customer = new Customer(new PIN(message.PIN), new Name(message.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(message.InitialAmount));
            account.Deposit(credit);

            customer.Register(account);

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            CustomerResponse customerResponse = responseConverter.Map<CustomerResponse>(customer);
            AccountResponse accountResponse = responseConverter.Map<AccountResponse>(account);
            RegisterResponse response = new RegisterResponse(customerResponse, accountResponse);

            outputBoundary.Populate(response);
        }
    }
}
