using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Pagination
{
    public class PagedList<T>: PaginationBase
    {
        public List<T> List { get; set; }
    }
}
