namespace MyAccountAPI.Domain.Model.Customers
{
    public class Amount
    {
        public double Value { get; private set; }

        public Amount(double value)
        {
            this.Value = value;
        }

        public static Amount Create(double value)
        {
            return new Amount(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
