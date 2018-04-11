namespace Castanha.MappingsTests
{
    using Castanha.Application;
    using Castanha.Application.Outputs;
    using Castanha.Domain.Accounts;
    using Castanha.Infrastructure.Mappings;
    using System;
    using Xunit;

    public class ConversionTests
    {
        public IOutputConverter converter;

        public ConversionTests()
        {
            converter = new OutputConverter();
        }

        [Fact]
        public void Convert_Debit_Valid_TransactionResponse()
        {
            Debit debit = new Debit(Guid.NewGuid(), 100);

            var result = converter.Map<TransactionOutput>(debit);
            Assert.Equal(debit.Amount.Value, result.Amount);
            Assert.Equal(debit.TransactionDate, result.TransactionDate);
            Assert.Equal(debit.Description, result.Description);
        }
    }
}
