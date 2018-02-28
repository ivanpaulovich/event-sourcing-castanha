namespace Castanha.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Castanha.Domain.Customers;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Application.ServiceBus;

    public class RegisterInteractor : IInputBoundary<RegisterInput>
    {
        private readonly IPublisher bus;
        private readonly IOutputBoundary<RegisterOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public RegisterInteractor(
            IPublisher bus,
            IOutputBoundary<RegisterOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(RegisterInput message)
        {
            Customer customer = new Customer(new PIN(message.PIN), new Name(message.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(message.InitialAmount));
            account.Deposit(credit);

            customer.Register(account);

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            CustomerOutput customerResponse = responseConverter.Map<CustomerOutput>(customer);
            AccountOutput accountResponse = responseConverter.Map<AccountOutput>(account);
            RegisterOutput response = new RegisterOutput(customerResponse, accountResponse);

            outputBoundary.Populate(response);
        }
    }
}
