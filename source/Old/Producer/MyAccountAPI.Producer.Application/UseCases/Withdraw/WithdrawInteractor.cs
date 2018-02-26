namespace MyAccountAPI.Producer.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;

    public class WithdrawInteractor : IInputBoundary<WithdrawCommand>
    {
        private readonly IOutputBoundary<WithdrawResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public WithdrawInteractor(
            IOutputBoundary<WithdrawResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(WithdrawCommand request)
        {
        }
    }
}
