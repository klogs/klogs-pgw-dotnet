using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemGroupProcessResponse: Response
    {
        public Guid PaymentSystemGroupId { get; set; }
    }
}
