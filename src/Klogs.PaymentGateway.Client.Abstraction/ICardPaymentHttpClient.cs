using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface ICardPaymentHttpClient
    {
        Task<PaymentTokenResponse> CreatePaymentTokenAsync();

        Task<CardPaymentResponse> PayAsync(CardPaymentRequest model);

        Task<Response> ProvisionCommitAsync(ProvisionCommitRequest model);

        Task<CommissionResponse> CommissionsByBinAsync(CommissionsRequest model);
    }
}
