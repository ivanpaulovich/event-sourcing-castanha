namespace Castanha.UseCaseTests
{
    using Xunit;
    using Castanha.Domain.Customers;
    using NSubstitute;
    using Castanha.Application;
    using Castanha.Infrastructure.Mappings;
    using System;
    using Castanha.Domain.ValueObjects;
    using Castanha.Application.ServiceBus;
    using Castanha.Application.Repositories;
    using Castanha.Domain.Accounts;

    public class AccountTests
    {
        public IAccountReadOnlyRepository accountReadOnlyRepository;
        public IAccountWriteOnlyRepository accountWriteOnlyRepository;
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public IPublisher bus;

        public IOutputConverter converter;

        public AccountTests()
        {
            accountReadOnlyRepository = Substitute.For<IAccountReadOnlyRepository>();
            accountWriteOnlyRepository = Substitute.For<IAccountWriteOnlyRepository>();
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();

            converter = new OutputConverter();
            bus = Substitute.For<IPublisher>();
        }

        [Theory]
        [InlineData("08724050601", "Ivan Paulovich", 300)]
        [InlineData("08724050601", "Ivan Paulovich Pinheiro Gomes", 100)]
        [InlineData("444", "Ivan Paulovich", 500)]
        [InlineData("08724050", "Ivan Paulovich", 300)]
        public async void Register_Valid_User_Account(string personnummer, string name, double amount)
        {
            var output = Substitute.For<CustomPresenter<Application.UseCases.Register.RegisterOutput>>();

            var registerUseCase = new Application.UseCases.Register.RegisterInteractor(
                customerReadOnlyRepository,
                accountReadOnlyRepository,
                bus,
                output,
                converter
            );

            var request = new Application.UseCases.Register.RegisterInput(
                personnummer,
                name,
                amount
            );

            await registerUseCase.Process(request);

            Assert.Equal(request.PIN, output.Response.Customer.Personnummer);
            Assert.Equal(request.Name, output.Response.Customer.Name);
            Assert.True(Guid.Empty != output.Response.Customer.CustomerId);
            Assert.True(Guid.Empty != output.Response.Account.AccountId);
        }


        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string accountId, double amount)
        {
            var account = Substitute.For<Account>();
            var customer = Substitute.For<Customer>();

            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(account);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Deposit.DepositOutput>>();

            var depositUseCase = new Application.UseCases.Deposit.DepositInteractor(
                accountReadOnlyRepository,
                bus,
                output,
                converter
            );

            var request = new Application.UseCases.Deposit.DepositInput(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Process(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, double amount)
        {
            Account account = Substitute.For<Account>();
            account.Deposit(new Credit(new Amount(amount)));

            accountReadOnlyRepository
                .Get(Guid.Parse(accountId))
                .Returns(account);

            var output = Substitute.For<CustomPresenter<Application.UseCases.Withdraw.WithdrawOutput>>();

            var depositUseCase = new Application.UseCases.Withdraw.WithdrawInteractor(
                accountReadOnlyRepository,
                bus,
                output,
                converter
            );

            var request = new Application.UseCases.Withdraw.WithdrawInput(
                Guid.Parse(accountId),
                amount
            );

            await depositUseCase.Process(request);

            Assert.Equal(request.Amount, output.Response.Transaction.Amount);
        }

        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Close(double amount)
        {
            var account = new Account();
            account.Deposit(new Credit(new Amount(amount)));

            Assert.Throws<AccountCannotBeClosedException>(
                () => account.Close());
        }
    }
}
