namespace MyAccountAPI.Producer.Application.UseCases.Deposit
{
    using System.Threading.Tasks;

    public class DepositInteractor : IInputBoundary<DepositCommand>
    {
        private readonly IOutputBoundary<DepositResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public DepositInteractor(
            IOutputBoundary<DepositResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(DepositCommand command)
        {
        }
    }
}
