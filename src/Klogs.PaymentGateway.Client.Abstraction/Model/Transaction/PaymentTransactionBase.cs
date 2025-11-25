using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class PaymentTransactionBase
    {
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public TransactionStatus Status { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public IEnumerable<TransactionError> Errors { get; set; }
    }
}
