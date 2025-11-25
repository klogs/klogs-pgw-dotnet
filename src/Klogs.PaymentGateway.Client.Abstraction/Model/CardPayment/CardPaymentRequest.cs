using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class CardPaymentRequest
    {
        public string Token { get; set; }

        public decimal Amount { get; set; }

        public int? Installment { get; set; }

        public string ReferenceCode { get; set; }

        public bool UseStoredCard { get; set; }

        public CreditCard Card { get; set; }

        public Reward Reward { get; set; }

        public Address Invoice { get; set; }

        public Address Shipping { get; set; }

        public string Explanation { get; set; }

        public bool Use3d { get; set; } = true;

        public Dictionary<string, string> AdditionalData { get; set; } = new Dictionary<string, string>();

        public string Currency { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ReturnURL { get; set; }

        public SalesType? ChargeType { get; set; }

        public Guid? PaymentSystemId { get; set; }

        public string NationalNumber { get; set; }

        public Product[] Products { get; set; } = Array.Empty<Product>();
    }
}
