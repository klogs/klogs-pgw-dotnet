namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class PageQueryBase
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string OrderBy { get; set; }

        public OrderDirection Dir { get; set; }
    }

    public enum OrderDirection
    {
        Asc,
        Desc
    }
}
