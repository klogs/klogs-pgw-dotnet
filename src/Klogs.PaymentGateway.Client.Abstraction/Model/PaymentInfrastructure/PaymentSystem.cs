using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string Code { get; set; }

        public string IssuerCode { get; set; }

        public PaymentOption[] PaymentOptions { get; set; }

        public string[] CurrencyCodes { get; set; }

        public SystemDefinition SystemDefinition { get; set; }

        public PaymentProvider PaymentProvider { get; set; }

        public CommApplyType? CommApplyType { get; set; }

        public SalesType? SalesType { get; set; }

        public PaymentSystemType SystemType { get; set; }

        public string[] PaymentMethods { get; set; }
    }
}
