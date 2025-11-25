using Klogs.PaymentGateway.Client.Abstraction.Model.PaymentLink;
using System.Threading.Tasks;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentLinkHttpClient
    {
        Task<PaymentLinkRecipientMetaModel> GetRecipientMetaModelAsync(string linkId);
    }
}
