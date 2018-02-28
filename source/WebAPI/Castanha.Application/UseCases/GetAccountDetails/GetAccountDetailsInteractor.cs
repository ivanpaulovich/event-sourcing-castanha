namespace Castanha.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Customers;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<AccountOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetAccountDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<AccountOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetAccountDetailsInput message)
        {
            var customer = await customerReadOnlyRepository.GetByAccount(message.AccountId);
            if (customer == null)
            {
                outputBoundary.Populate(null);
                return;
            }

            var account = customer.FindAccount(message.AccountId);
            AccountOutput response = responseConverter.Map<AccountOutput>(account);
            outputBoundary.Populate(response);
        }
    }
}
