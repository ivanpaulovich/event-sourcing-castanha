namespace Castanha.Domain.UnitTests
{
    using Xunit;
    using Castanha.Domain.Customers;
    using NSubstitute;
    using Castanha.Domain.ValueObjects;
    using Castanha.Domain.Accounts;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            //
            // Arrange
            Customer sut = new Customer(new PIN("08724050601"), new Name("Ivan Paulovich"));
            Account account = Substitute.For<Account>();

            //
            // Act
            sut.Register(account.Id);

            //
            // Assert
            Assert.Single(sut.Accounts);
        }
    }
}
