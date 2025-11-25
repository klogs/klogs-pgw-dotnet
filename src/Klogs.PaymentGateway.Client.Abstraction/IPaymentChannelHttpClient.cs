using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Channel;
using System;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentChannelHttpClient
    {
        Task<PaymentChannelListResponse> ListAsync(PageQueryBase query);

        Task<Response> AddAsync(PaymentChannelRequest model);

        Task<Response> UpdateAsync(Guid id, PaymentChannelRequest model);

        Task<Response> DeleteAsync(Guid id);
    }
}
