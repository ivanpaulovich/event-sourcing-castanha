namespace MyAccountAPI.Producer.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using MyAccountAPI.Producer.Application.Responses;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsCommand>
    {
        private readonly IOutputBoundary<AccountResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetAccountDetailsInteractor(
            IOutputBoundary<AccountResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(GetAccountDetailsCommand message)
        {
        }
    }
}
