using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class PaymentSystemGroupListResponse : Response
    {
        public PagedList<PaymentSystemGroup> List { get; set; }
    }
}
