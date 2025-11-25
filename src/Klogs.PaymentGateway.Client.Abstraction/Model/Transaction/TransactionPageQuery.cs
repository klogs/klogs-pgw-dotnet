using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class TransactionPageQuery : PageQueryBase
    {
        public string Search { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public string ApplicationCode { get; set; }

        public string PaymentProviderId { get; set; }

        public TransactionType? Type { get; set; }

        public TransactionStatus? Status { get; set; }
    }
}
