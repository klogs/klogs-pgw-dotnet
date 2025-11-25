using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Pagination
{
    public abstract class PaginationBase
    {
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }

        public bool HasNext { get; set; }

        public bool HasPrevious { get; set; }

        public string StateKey { get; set; }

        public IEnumerable<int?> Pages => PageNumber.Numbers(CurrentPage, PageCount);
    }
}
