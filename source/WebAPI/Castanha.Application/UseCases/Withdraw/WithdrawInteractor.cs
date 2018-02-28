namespace Castanha.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.ServiceBus;

    public class WithdrawInteractor : IInputBoundary<WithdrawInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IPublisher bus;
        private readonly IOutputBoundary<WithdrawOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public WithdrawInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<WithdrawOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(WithdrawInput command)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(command.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            Account account = customer.FindAccount(command.AccountId);
            account.Deposit(credit);

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            TransactionOutput transactionResponse = responseConverter.Map<TransactionOutput>(credit);
            WithdrawOutput response = new WithdrawOutput(transactionResponse, account.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
