using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentProvidersResponse : Response
    {
        public List<PaymentProvider> Providers { get; set; }
    }
}
