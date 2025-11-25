using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class TransactionListResponse : Response
    {
        public PagedList<PaymentTransaction> List { get; set; }
    }
}
