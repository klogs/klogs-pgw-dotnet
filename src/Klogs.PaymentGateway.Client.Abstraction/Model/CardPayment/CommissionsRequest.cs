using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class CommissionsRequest
    {
        public string BinNumber { get; set; }

        public decimal? Amount { get; set; }

        public CurrencyType Currency { get; set; }

        public string[] ProductCategoryCodes { get; set; }

        public string[] ProductCodes { get; set; }

        public Guid? CardId { get; set; }
    }
}
