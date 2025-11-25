namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class CommissionsRequest
    {
        public string BinNumber { get; set; }

        public decimal? Amount { get; set; }

        public CurrencyType Currency { get; set; }
    }
}
