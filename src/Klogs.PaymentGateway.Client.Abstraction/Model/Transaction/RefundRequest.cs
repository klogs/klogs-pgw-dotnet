namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class RefundRequest
    {
        public string ReferenceCode { get; set; }

        public decimal Amount { get; set; }
    }
}
