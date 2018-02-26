namespace MyAccountAPI.Producer.Application.UseCases.CloseAccount
{
    using System.Threading.Tasks;

    public class CloseInteractor : IInputBoundary<CloseCommand>
    {
        private readonly IOutputBoundary<CloseResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public CloseInteractor(
            IOutputBoundary<CloseResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(CloseCommand request)
        {
        }
    }
}