namespace Castanha.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Castanha.Application.Responses;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.ServiceBus;

    public class WithdrawInteractor : IInputBoundary<WithdrawCommand>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IPublisher bus;
        private readonly IOutputBoundary<WithdrawResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public WithdrawInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<WithdrawResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(WithdrawCommand command)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(command.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            Account account = customer.FindAccount(command.AccountId);
            account.Deposit(credit);

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(credit);
            WithdrawResponse response = new WithdrawResponse(transactionResponse, account.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
