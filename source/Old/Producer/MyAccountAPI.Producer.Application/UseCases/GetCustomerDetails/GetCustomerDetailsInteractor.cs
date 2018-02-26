namespace MyAccountAPI.Producer.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using MyAccountAPI.Producer.Application.Responses;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetaisCommand>
    {
        private readonly IOutputBoundary<CustomerResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetCustomerDetailsInteractor(
            IOutputBoundary<CustomerResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(GetCustomerDetaisCommand message)
        {
        }
    }
}