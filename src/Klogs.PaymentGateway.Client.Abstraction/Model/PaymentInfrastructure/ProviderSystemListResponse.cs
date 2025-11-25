using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class ProviderSystemListResponse : Response
    {
        public List<ProviderSupportedSystem> ProviderSystems { get; set; }
    }
}
