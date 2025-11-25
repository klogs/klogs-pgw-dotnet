using Klogs.PaymentGateway.Client.Abstraction;
using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Services
{
    internal class CardPaymentHttpClient : KlogsHttpClient, ICardPaymentHttpClient
    {
        public CardPaymentHttpClient(HttpClient httpClient) : base(httpClient)
        {
            
        }

        public Task<PaymentTokenResponse> CreatePaymentTokenAsync()
        {
            return GetAsync<PaymentTokenResponse>(resourceUri: "/api/cardPayment/token");
        }

        public Task<CardPaymentResponse> PayAsync(CardPaymentRequest model)
        {
            return PostAsync<CardPaymentResponse>("/api/cardPayment", model);
        }

        public Task<Response> ProvisionCommitAsync(ProvisionCommitRequest model)
        {
            return PostAsync<Response>("/api/cardPayment/provisionCommit", model);
        }

        public Task<CommissionResponse> CommissionsByBinAsync(CommissionsRequest model)
        {
            var requestUri = "/api/cardPayment/installments".ToUri()
                                                            .AddQuery(new
                                                            {
                                                                amount = model.Amount?.ToString(CultureInfo.InvariantCulture),
                                                                binNumber = model.BinNumber,
                                                                currency = model.Currency.Iso4217
                                                            })
                                                            .ToString();

            return GetAsync<CommissionResponse>(requestUri);
        }
    }
}
