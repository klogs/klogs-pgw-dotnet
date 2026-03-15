using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.Abstraction.Model.Transaction;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentTransactionHttpClient
    {
        Task<TransactionDetailResponse> DetailAsync(string reference);

        Task<Response> VoidAsync(VoidRequest model);

        Task<Response> RefundAsync(RefundRequest model);
    }
}