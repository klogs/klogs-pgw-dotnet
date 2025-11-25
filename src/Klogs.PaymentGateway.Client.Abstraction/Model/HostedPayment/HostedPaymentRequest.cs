using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.HostedPayment
{
    public class HostedPaymentRequest
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Reference { get; set; }

        public Address Invoice { get; set; }

        public Address Shipping { get; set; }

        public string Explanation { get; set; }

        public Dictionary<string, string> AdditionalData { get; set; } = new Dictionary<string, string>();

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ReturnURL { get; set; }

        public SalesType? ChargeType { get; set; }

        public string FullName { get; set; }

        public string NationalNumber { get; set; }

        public Product[] Products { get; set; }

        public Guid? PaymentSystemId { get; set; }

        public Guid? PaymentSystemGroupId { get; set; }
    }
}
