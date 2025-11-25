using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemGroup
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Enabled { get; set; }

        public IdName[] PaymentSystems { get; set; }

        public int PaymentSystemLength => PaymentSystems?.Length ?? 0;
    }
}
