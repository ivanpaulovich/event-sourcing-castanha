namespace Castanha.Domain.UnitTests
{
    using Xunit;
    using Castanha.Domain.Customers;
    using NSubstitute;
    using Castanha.Application;
    using Castanha.Infrastructure.Mappings;
    using Castanha.UseCaseTests;
    using System;
    using Castanha.Application.ServiceBus;

    public class CustomerTests
    {
        public ICustomerReadOnlyRepository customerReadOnlyRepository;
        public ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        public IPublisher bus;

        public IOutputConverter converter;

        public CustomerTests()
        {
            customerReadOnlyRepository = Substitute.For<ICustomerReadOnlyRepository>();
            customerWriteOnlyRepository = Substitute.For<ICustomerWriteOnlyRepository>();
            bus = Substitute.For<IPublisher>();
            converter = new OutputConverter();
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
            Assert.True(output.Response.Customer.CustomerId != Guid.Empty);
            Assert.True(output.Response.Account.AccountId != Guid.Empty);
        }
    }
}
