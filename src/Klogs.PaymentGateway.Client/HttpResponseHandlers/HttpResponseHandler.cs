using Klogs.PaymentGateway.Client.Abstraction.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.HttpResponseHandlers
{
    public delegate Task<T> HttpResponseHandler<T>(HttpResponseMessage response) where T : Response;
}
