using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model.HostedPayment;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class HostedPaymentHttpClient : KlogsHttpClient, IHostedPaymentHttpClient
    {
        public HostedPaymentHttpClient(HttpClient httpClient):base(httpClient)
        {
        }

        public Task<CreateHostedPaymentResponse> CreatePayment(HostedPaymentRequest model)
        {
            return PostAsync<CreateHostedPaymentResponse>("/api/payment", model);
        }
    }
}
