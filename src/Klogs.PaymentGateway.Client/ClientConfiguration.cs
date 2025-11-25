using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client
{
    public class ClientConfiguration
    {
        public string Endpoint { get; set; }

        //internal Dictionary<string, IClientAuthenticator> Authenticators { get; set; } = new Dictionary<string, IClientAuthenticator>();

        //public virtual void Authenticate(HttpClient client)
        //{
        //    foreach (var authenticator in Authenticators)
        //    {
        //        authenticator.Value.Authenticate(client);
        //    }
        //}

        public Dictionary<string, string> AdditionalHeaders { get; set; }
    }
}
