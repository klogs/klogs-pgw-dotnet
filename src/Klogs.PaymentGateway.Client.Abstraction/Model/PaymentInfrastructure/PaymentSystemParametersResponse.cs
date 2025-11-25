using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemParametersResponse : Response
    {
        public List<PaymentSystemParameter> Parameters { get; set; }
    }
}
