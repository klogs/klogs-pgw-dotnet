namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class PaymentProvider
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Version { get; set; }

        public string IssuerCode { get; set; }

        public ProviderSupportedSystem[] SupportedSystems { get; set; }

        public PaymentSystemType SystemType { get; set; }

        public string[] SupportedCurrencies { get; set; }

        public string[] SupportedPaymentMethods { get; set; }
    }
}
