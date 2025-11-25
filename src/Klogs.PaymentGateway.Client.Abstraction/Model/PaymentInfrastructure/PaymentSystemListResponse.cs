using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemListResponse : Response
    {
        public PagedList<PaymentSystem> List { get; set; }
    }
}
