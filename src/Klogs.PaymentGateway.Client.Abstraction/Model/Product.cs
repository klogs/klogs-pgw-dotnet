namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class Product
    {
        public string Id { get; set; }

        public string Category { get; set; }

        public double Quantity { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
