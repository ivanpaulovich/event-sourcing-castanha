namespace Castanha.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Customers;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetaisInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IOutputBoundary<CustomerOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetCustomerDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IOutputBoundary<CustomerOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetCustomerDetaisInput message)
        {
            Domain.Customers.Customer customer = await this.customerReadOnlyRepository.Get(message.CustomerId);
            CustomerOutput response = responseConverter.Map<CustomerOutput>(customer);

            outputBoundary.Populate(response);
        }
    }
}