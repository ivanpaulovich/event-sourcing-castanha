namespace Manga.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;
    using Manga.Domain.Customers;
    using Manga.Domain.Customers.Accounts;
    using Manga.Application.ServiceBus;

    public class CloseInteractor : IInputBoundary<CloseCommand>
    {
        private readonly IPublisher bus;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<CloseResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public CloseInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<CloseResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.bus = bus;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(CloseCommand request)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(request.AccountId);
            Account account = customer.FindAccount(request.AccountId);

            account.Close();

            var domainEvents = customer.GetEvents();
            await bus.Publish(domainEvents);

            CloseResponse response = responseConverter.Map<CloseResponse>(account);
            this.outputBoundary.Populate(response);
        }
    }
}