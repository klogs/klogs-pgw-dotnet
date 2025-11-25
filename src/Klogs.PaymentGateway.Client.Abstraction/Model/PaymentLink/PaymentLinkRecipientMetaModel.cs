using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentLink
{
    public class PaymentLinkRecipientMetaModel : Response
    {
        public string LinkId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool AllowAmountChange { get; set; }

        public decimal AmountMaxLimit { get; set; }

        public decimal AmountMinLimit { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        public string ApiKey { get; set; }

        public string PaymentPageLink { get; set; }

        public Guid PaymentLinkId { get; set; }

        public string FullName { get; set; }

        public LinkItem[] LinkItems { get; set; }
    }
}
