namespace MyAccountAPI.Producer.Application.UseCases.Register
{
    using System.Threading.Tasks;

    public class RegisterInteractor : IInputBoundary<RegisterCommand>
    {
        private readonly IOutputBoundary<RegisterResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public RegisterInteractor(
            IOutputBoundary<RegisterResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(RegisterCommand message)
        {
        }
    }
}
