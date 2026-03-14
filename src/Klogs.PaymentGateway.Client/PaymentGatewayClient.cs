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

        public PaymentGatewayClient(HttpClient http)
        {
            _http = http;
        }

        public PaymentGatewayClient(string apiKey, string secretKey, string endpoint = "https://pgw.klogs.io")
        {
            _http = KlogsHttp.GetOrCreate(endpoint, apiKey, secretKey);
        }

        public ICardPaymentHttpClient CardPayment => new CardPaymentHttpClient(_http);

        public IHostedPaymentHttpClient HostedPayment => new HostedPaymentHttpClient(_http);

        public IPaymentTransactionHttpClient Transaction => new PaymentTransactionHttpClient(_http);

        public void Dispose()
        {
            _http?.Dispose();
        }
    }
}
