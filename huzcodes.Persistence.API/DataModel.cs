namespace huzcodes.Persistence.API
{
    public class DataModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int PriceWithoutTax { get; set; }

        public decimal Price => 32 + (int)(PriceWithoutTax / 0.5556);

        public string ProductName { get; set; } = string.Empty;
    }
}
