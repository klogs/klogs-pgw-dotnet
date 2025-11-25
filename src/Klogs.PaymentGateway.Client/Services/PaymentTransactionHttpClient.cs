using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;
using Klogs.PaymentGateway.Client.Abstraction.Model.Transaction;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class PaymentTransactionHttpClient : KlogsHttpClient, IPaymentTransactionHttpClient
    {
        public PaymentTransactionHttpClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<TransactionDetailResponse> DetailAsync(string reference)
        {
            return await GetAsync($"api/trx/{reference}", responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PaymentTransactionDetail>(content, JsonOptions);

                return new TransactionDetailResponse { Transaction = responseObj };
            });
        }

        public async Task<TransactionListResponse> ListAsync(TransactionPageQuery query)
        {
            var requestUri = $"api/trx".ToUri().AddQuery(query).ToString();

            return await GetAsync(requestUri, responseHandler: async response =>
            {
                var content = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<PagedList<PaymentTransaction>>(content, JsonOptions);

                return new TransactionListResponse { List = responseObj };
            });

        }

        public Task<Response> RefundAsync(RefundRequest model)
        {
            return PostAsync<Response>("/api/cardPayment/refund", model);
        }

        public Task<Response> VoidAsync(VoidRequest model)
        {
            return PostAsync<Response>("/api/cardPayment/void", model);
        }
    }
}
