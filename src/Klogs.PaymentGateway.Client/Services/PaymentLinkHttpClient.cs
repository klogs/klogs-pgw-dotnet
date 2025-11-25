using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentLink;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class PaymentLinkHttpClient : KlogsHttpClient, IPaymentLinkHttpClient
    {
        public PaymentLinkHttpClient(HttpClient httpClient) : base(httpClient) { }

        public Task<PaymentLinkRecipientMetaModel> GetRecipientMetaModelAsync(string linkId)
        {
            return GetAsync<PaymentLinkRecipientMetaModel>($"api/paymentLink/recipient-meta/{linkId}");
        }
    }
}
