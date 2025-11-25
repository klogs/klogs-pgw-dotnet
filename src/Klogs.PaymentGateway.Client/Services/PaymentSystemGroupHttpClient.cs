using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;
using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class PaymentSystemGroupHttpClient : KlogsHttpClient, IPaymentSystemGroupHttpClient
    {
        public PaymentSystemGroupHttpClient(HttpClient httpClient) : base(httpClient) { }

        public Task<Response> AddPaymentSystem(Guid paymentSystemGroupId, Guid paymentSystemId)
        {
            return PutAsync<Response>($"/api/paymentSystemGroup/{paymentSystemGroupId}/{paymentSystemId}", body: null);
        }

        public Task<PaymentSystemGroupProcessResponse> CreateAsync(PaymentSystemGroupRequest model)
        {
            return PostAsync<PaymentSystemGroupProcessResponse>("/api/paymentSystemGroup", model);
        }

        public Task<Response> DeleteAsync(Guid paymentSystemGroupId)
        {
            return DeleteAsync<Response>($"/api/paymentSystemGroup/{paymentSystemGroupId}");
        }

        public async Task<PaymentSystemGroupResponse> FindByIdAsync(Guid id)
        {
            return await GetAsync($"api/paymentSystemGroup/{id}", responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PaymentSystemGroup>(content, JsonOptions);

                return new PaymentSystemGroupResponse { PaymentSystemGroup = responseObj };
            });
        }

        public async Task<PaymentSystemGroupListResponse> ListAsync(PageQueryBase query)
        {
            var requestUri = "api/paymentSystemGroup".ToUri().AddQuery(query).ToString();

            return await GetAsync(requestUri, responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PagedList<PaymentSystemGroup>>(content, JsonOptions);

                return new PaymentSystemGroupListResponse { List = responseObj };
            });
        }

        public Task<Response> RemovePaymentSystem(Guid paymentSystemGroupId, Guid paymentSystemId)
        {
            return DeleteAsync<Response>($"/api/paymentSystemGroup/{paymentSystemGroupId}/{paymentSystemId}");
        }

        public Task<PaymentSystemGroupProcessResponse> UpdateAsync(Guid paymentSystemGroupId, PaymentSystemGroupRequest model)
        {
            return PutAsync<PaymentSystemGroupProcessResponse>($"/api/paymentSystemGroup/{paymentSystemGroupId}", model);
        }
    }
}
