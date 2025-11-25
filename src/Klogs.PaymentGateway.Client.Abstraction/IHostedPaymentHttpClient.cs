using Klogs.PaymentGateway.Client.Abstraction.Model.HostedPayment;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IHostedPaymentHttpClient
    {
        Task<CreateHostedPaymentResponse> CreatePayment(HostedPaymentRequest model);
    }
}
