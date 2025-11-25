namespace Klogs.PaymentGateway.Client.Abstraction.Model.HostedPayment
{
    public class CreateHostedPaymentResponse : Response
    {
        public string Link { get; set; }

        public string PaymentId { get; set; }
    }
}
