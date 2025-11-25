using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class CommRateResponse : Response
    {
        public List<Commission> CommRates { get; set; }
    }
}
