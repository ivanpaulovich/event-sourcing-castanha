namespace Castanha.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Application.ServiceBus;

    public class CloseInteractor : IInputBoundary<CloseInput>
    {
        private readonly IPublisher bus;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<CloseOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public CloseInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<CloseOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.bus = bus;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(CloseInput request)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(request.AccountId);
            Account account = customer.FindAccount(request.AccountId);

            account.Close();

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            CloseOutput response = responseConverter.Map<CloseOutput>(account);
            this.outputBoundary.Populate(response);
        }
    }
}