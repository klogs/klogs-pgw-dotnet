using Klogs.PaymentGateway.Client.Abstraction.Model.Pagination;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Channel
{
    public class PaymentChannelListResponse : Response
    {
        public PagedList<PaymentChannel> List { get; set; }
    }
}
