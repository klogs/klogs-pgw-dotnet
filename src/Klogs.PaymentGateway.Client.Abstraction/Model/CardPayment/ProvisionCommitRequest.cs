namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class ProvisionCommitRequest
    {
        public string ReferenceCode { get; set; }

        public decimal? Amount { get; set; }
    }
}
