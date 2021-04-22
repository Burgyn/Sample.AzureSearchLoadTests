namespace Sample.AzureSearchLoadTests
{
    public class OrderItem
    {
        public long Id { get; set; }

        public long Ordinal { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public string MeasureUnit { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public string Description { get; set; }

        public string Ean { get; set; }
    }
}
