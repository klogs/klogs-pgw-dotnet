using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Channel;
using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class PaymentChannelHttpClient : KlogsHttpClient, IPaymentChannelHttpClient
    {
        public PaymentChannelHttpClient(HttpClient httpClient) : base(httpClient) { }

        public Task<Response> AddAsync(PaymentChannelRequest model)
        {
            return PostAsync<Response>("api/paymentChannel", model);
        }

        public Task<Response> DeleteAsync(Guid id)
        {
            return DeleteAsync<Response>($"api/paymentChannel/{id}");
        }

        public async Task<PaymentChannelListResponse> ListAsync(PageQueryBase query)
        {
            var requestUri = "api/paymentChannel".ToUri().AddQuery(query).ToString();

            return await GetAsync(requestUri, responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PagedList<PaymentChannel>>(content, JsonOptions);

                return new PaymentChannelListResponse { List = responseObj };
            });
        }

        public Task<Response> UpdateAsync(Guid id, PaymentChannelRequest model)
        {
            return PutAsync<Response>($"api/paymentChannel/{id}", model);
        }
    }
}
