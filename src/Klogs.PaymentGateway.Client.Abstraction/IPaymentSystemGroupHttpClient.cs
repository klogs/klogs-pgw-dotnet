using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure;
using System;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentSystemGroupHttpClient
    {
        Task<PaymentSystemGroupResponse> FindByIdAsync(Guid id);

        Task<PaymentSystemGroupListResponse> ListAsync(PageQueryBase query);

        Task<PaymentSystemGroupProcessResponse> CreateAsync(PaymentSystemGroupRequest model);

        Task<PaymentSystemGroupProcessResponse> UpdateAsync(Guid paymentSystemGroupId, PaymentSystemGroupRequest model);

        Task<Response> DeleteAsync(Guid paymentSystemGroupId);

        Task<Response> AddPaymentSystem(Guid paymentSystemGroupId, Guid paymentSystemId);

        Task<Response> RemovePaymentSystem(Guid paymentSystemGroupId, Guid paymentSystemId);
    }
}
