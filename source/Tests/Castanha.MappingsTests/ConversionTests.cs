namespace Castanha.MappingsTests
{
    using Castanha.Application;
    using Castanha.Application.Responses;
    using Castanha.Domain.Customers.Accounts;
    using Castanha.Domain.ValueObjects;
    using Castanha.Infrastructure.Mappings;
    using Xunit;

    public class ConversionTests
    {
        public IResponseConverter converter;

        public ConversionTests()
        {
            converter = new ResponseConverter();
        }

        [Fact]
        public void Convert_Debit_Valid_TransactionResponse()
        {
            Debit debit = new Debit(new Amount(100));

            var result = converter.Map<TransactionResponse>(debit);
            Assert.Equal(debit.Amount.Value, result.Amount);
            Assert.Equal(debit.TransactionDate, result.TransactionDate);
            Assert.Equal(debit.Description, result.Description);
        }
    }
}
