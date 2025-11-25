using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemProcessResponse : Response
    {
        public Guid PaymentSystemId { get; set; }
    }
}
