using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Channel
{
    public class PaymentChannel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool Enabled { get; set; }

        public string ApiKey { get; set; }
    }
}
