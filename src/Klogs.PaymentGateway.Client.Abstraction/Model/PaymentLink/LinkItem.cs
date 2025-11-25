using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentLink
{
    public class LinkItem
    {
        public Guid Id { get; set; }

        public bool IsPaid { get; set; }

        public decimal Price { get; set; }

        public string Code { get; set; }

        public bool Mandatory { get; set; }

        public string Description { get; set; }
    }
}
