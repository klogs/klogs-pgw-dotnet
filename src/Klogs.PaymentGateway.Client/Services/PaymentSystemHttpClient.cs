using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;
using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class PaymentSystemHttpClient : KlogsHttpClient, IPaymentSystemHttpClient
    {
        public PaymentSystemHttpClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<PaymentSystemResponse> FindByIdAsync(Guid id)
        {
            return await GetAsync($"api/paymentSystem/{id}", responseHandler:async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<PaymentSystem>(content, JsonOptions);

                return new PaymentSystemResponse { PaymentSystem = data };
            });
        }

        public async Task<PaymentSystemListResponse> ListAsync(PageQueryBase query)
        {
            var requestUri = "api/paymentSystem".ToUri().AddQuery(query).ToString();

            return await GetAsync(requestUri, responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PagedList<PaymentSystem>>(content, JsonOptions);

                return new PaymentSystemListResponse { List = responseObj };
            });
        }

        public Task<PaymentSystemProcessResponse> CreateAsync(PaymentSystemRequest model)
        {
            return PostAsync<PaymentSystemProcessResponse>("/api/paymentSystem", model);
        }

        public Task<PaymentSystemProcessResponse> UpdateAsync(Guid paymentSystemId, PaymentSystemRequest model)
        {
            return PutAsync<PaymentSystemProcessResponse>($"/api/paymentSystem/{paymentSystemId}", model);
        }

        public Task<Response> DeleteAsync(Guid paymentSystemId)
        {
            return DeleteAsync<Response>($"/api/paymentSystem/{paymentSystemId}");
        }

        public Task<Response> SyncCommRatesAsync(Guid paymentSystemId, List<Commission> installments)
        {
            return PutAsync<Response>($"/api/paymentSystem/{paymentSystemId}/installments", new { installments });
        }

        public async Task<PaymentSystemParametersResponse> GetParametersAsync(Guid? paymentSystemId, string systemKey)
        {
            var requestUri = $"/api/paymentSystem/parameters".ToUri();

            if (paymentSystemId != null)
            {
                requestUri = requestUri.AddQuery(new { paymentSystemId });
            }

            if (!string.IsNullOrWhiteSpace(systemKey))
            {
                requestUri = requestUri.AddQuery(new { sysKey = systemKey });
            }

            return await GetAsync(requestUri.ToString(), responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<PaymentSystemParameter>>(content, JsonOptions);

                return new PaymentSystemParametersResponse { Parameters = responseObj };
            });
        }

        public Task<Response> SaveParametersAsync(Guid paymentSystemId, List<NameValueModel> model)
        {
            return PutAsync<Response>($"/api/paymentSystem/{paymentSystemId}/parameters", model);
        }

        public async Task<PaymentProvidersResponse> ProvidersAsync()
        {
            return await GetAsync($"/api/paymentSystem/provider", responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<PaymentProvider>>(content, JsonOptions);

                return new PaymentProvidersResponse { Providers = responseObj };
            });
        }

        public async Task<ProviderSystemListResponse> SupportedPaymentSystemsAsync(string issuerCode)
        {
            return await GetAsync($"/api/paymentSystem/supportedSystem/{issuerCode}", responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<ProviderSupportedSystem>>(content, JsonOptions);

                return new ProviderSystemListResponse { ProviderSystems = responseObj };
            });
        }

        public async Task<CommRateResponse> GetCommRatesAsync(Guid paymentSystemId)
        {
            var requestUri = $"/api/paymentSystem/{paymentSystemId}/installments".ToUri().ToString();

            return await GetAsync(requestUri, responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<Commission>>(content, JsonOptions);

                return new CommRateResponse { CommRates = responseObj };
            });
        }
    }
}
