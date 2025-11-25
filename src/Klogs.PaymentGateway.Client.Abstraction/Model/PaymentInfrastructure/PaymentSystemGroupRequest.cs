using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemGroupRequest
    {
        public string Title { get; set; }

        public bool Enabled { get; set; }

        public Guid[] PaymentSystems { get; set; }
    }
}
