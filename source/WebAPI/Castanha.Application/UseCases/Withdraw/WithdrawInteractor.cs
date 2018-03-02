﻿namespace Castanha.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Customers;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.ServiceBus;
    using Castanha.Application.Repositories;
    using Castanha.Domain.Accounts;

    public class WithdrawInteractor : IInputBoundary<WithdrawInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IPublisher bus;
        private readonly IOutputBoundary<WithdrawOutput> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public WithdrawInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IPublisher bus,
            IOutputBoundary<WithdrawOutput> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(WithdrawInput command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            account.Deposit(credit);

            var domainEvents = account.GetEvents();
            await bus.Publish(domainEvents);

            TransactionOutput transactionResponse = responseConverter.Map<TransactionOutput>(credit);
            WithdrawOutput response = new WithdrawOutput(transactionResponse, account.GetCurrentBalance().Value);

            outputBoundary.Populate(response);
        }
    }
}