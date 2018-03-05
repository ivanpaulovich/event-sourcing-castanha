namespace Castanha.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Castanha.Domain.Customers;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.Outputs;
    using Castanha.Application.ServiceBus;
    using Castanha.Domain.Accounts;

    public class RegisterInteractor : IInputBoundary<RegisterInput>
    {
        private readonly IPublisher bus;
        private readonly IOutputBoundary<RegisterOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;
        
        public RegisterInteractor(
            IPublisher bus,
            IOutputBoundary<RegisterOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(RegisterInput message)
        {
            Customer customer = new Customer(
                new PIN(message.PIN), 
                new Name(message.Name));

            Account account = new Account();
            account.Open(new Credit(new Amount(message.InitialAmount)));
            customer.Register(account.Id);

            var customerEvents = customer.GetEvents();
            var accountEvents = account.GetEvents();

            await bus.Publish(customerEvents);
            await bus.Publish(accountEvents);

            CustomerOutput customerOutput = responseConverter.Map<CustomerOutput>(customer);
            AccountOutput accountOutput = responseConverter.Map<AccountOutput>(account);
            RegisterOutput output = new RegisterOutput(customerOutput, accountOutput);

            outputBoundary.Populate(output);
        }
    }
}
