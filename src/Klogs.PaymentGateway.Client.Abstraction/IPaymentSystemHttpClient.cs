using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentSystemHttpClient
    {
        Task<PaymentSystemResponse> FindByIdAsync(Guid id);

        Task<PaymentSystemListResponse> ListAsync(PageQueryBase query);

        Task<PaymentSystemProcessResponse> CreateAsync(PaymentSystemRequest model);

        Task<PaymentSystemProcessResponse> UpdateAsync(Guid paymentSystemId, PaymentSystemRequest model);

        Task<Response> DeleteAsync(Guid paymentSystemId);

        Task<Response> SyncCommRatesAsync(Guid paymentSystemId, List<Commission> installments);

        Task<CommRateResponse> GetCommRatesAsync(Guid paymentSystemId);

        Task<PaymentSystemParametersResponse> GetParametersAsync(Guid? paymentSystemId, string systemKey);

        Task<Response> SaveParametersAsync(Guid paymentSystemId, List<NameValueModel> model);

        Task<PaymentProvidersResponse> ProvidersAsync();

        Task<ProviderSystemListResponse> SupportedPaymentSystemsAsync(string issuerCode);
    }
}
