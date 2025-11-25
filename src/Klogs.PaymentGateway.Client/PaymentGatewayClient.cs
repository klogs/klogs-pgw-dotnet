using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Services;
using Klogs.PaymentGateway.Client.Utility;
using System.Collections.Generic;
using System.Net.Http;

namespace Klogs.PaymentGateway.Client
{
    public sealed class PaymentGatewayClient : IPaymentGatewayClient
    {
        private readonly HttpClient _http;

        public PaymentGatewayClient(string endpoint = "https://pgw.klogs.io", string apiKey = null, string secretKey = null, Dictionary<string, string> additionalHeaders = null)
        {
            _http = KlogsHttp.GetOrCreate(endpoint, apiKey, secretKey, additionalHeaders);
        }

        public PaymentGatewayClient(HttpClient http)
        {
            _http = http;
        }

        public ICardPaymentHttpClient CardPayment => new CardPaymentHttpClient(_http);

        public IHostedPaymentHttpClient HostedPayment => new HostedPaymentHttpClient(_http);

        public IPaymentChannelHttpClient PaymentChannel => new PaymentChannelHttpClient(_http);

        public IPaymentSystemGroupHttpClient PaymentSystemGroup => new PaymentSystemGroupHttpClient(_http);

        public IPaymentSystemHttpClient PaymentSystem => new PaymentSystemHttpClient(_http);

        public IPaymentTransactionHttpClient Transaction => new PaymentTransactionHttpClient(_http);

        public void Dispose()
        {
            _http?.Dispose();
        }
    }
}
