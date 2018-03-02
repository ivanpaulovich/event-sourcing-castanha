namespace Castanha.Application.UseCases.GetAccountDetails
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Application.Repositories;

    public class GetAccountDetailsInteractor : IInputBoundary<GetAccountDetailsInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<AccountOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetAccountDetailsInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<AccountOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetAccountDetailsInput message)
        {
            var account = await accountReadOnlyRepository.Get(message.AccountId);
            if (account == null)
            {
                outputBoundary.Populate(null);
                return;
            }

            AccountOutput response = responseConverter.Map<AccountOutput>(account);
            outputBoundary.Populate(response);
        }
    }
}
