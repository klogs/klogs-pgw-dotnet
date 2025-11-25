namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class CardPaymentResponse : Response
    {
        public string Behavior { get; set; }

        public string Link { get; set; }
    }
}
