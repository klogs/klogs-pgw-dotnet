using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client
{
    public class ClientConfiguration
    {
        public string Endpoint { get; set; }

        public Dictionary<string, string> AdditionalHeaders { get; set; }
    }
}
