namespace Castanha.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Application.Repositories;
    using Castanha.Domain.Customers;
    using Castanha.Domain.Accounts;
    using System.Collections.Generic;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetailsInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<CustomerOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public GetCustomerDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<CustomerOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetCustomerDetailsInput message)
        {
            //
            // TODO: The following queries could be simplified
            //

            Customer customer = await customerReadOnlyRepository.Get(message.CustomerId);

            List<AccountOutput> accounts = new List<AccountOutput>();

            foreach (var accountId in customer.Accounts.Items)
            {
                Account account = await accountReadOnlyRepository.Get(accountId);

                //
                // TODO: The "Accout closed state" is not propagating to the Customer Aggregate
                //

                if (account != null)
                {
                    AccountOutput accountOutput = responseConverter.Map<AccountOutput>(account);
                    accounts.Add(accountOutput);
                }
            }

            CustomerOutput response = responseConverter.Map<CustomerOutput>(customer);

            response = new CustomerOutput(
                customer.Id,
                customer.PIN.Text, 
                customer.Name.Text, 
                accounts);

            outputBoundary.Populate(response);
        }
    }
}