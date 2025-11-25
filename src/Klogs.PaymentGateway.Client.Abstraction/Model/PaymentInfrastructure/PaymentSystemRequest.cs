namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemRequest
    {
        public string Name { get; set; }

        public string PaymentProviderId { get; set; }

        public string SystemKey { get; set; }

        public string[] Currencies { get; set; }

        public bool Enabled { get; set; }

        public string Code { get; set; }

        public PaymentOption[] PaymentOptions { get; set; }

        public SalesType? SalesType { get; set; }

        public string[] PaymentMethods { get; set; }

        public CommApplyType? CommApplyType { get; set; }

        public bool WebhookEnabled { get; set; }
    }
}
