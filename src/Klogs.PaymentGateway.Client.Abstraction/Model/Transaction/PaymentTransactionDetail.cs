using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class PaymentTransactionDetail : PaymentTransaction
    {
        public List<PaymentTransactionBase> RelatedTransactions { get; set; } = new List<PaymentTransactionBase>();

        public PaymentProvider PaymentProvider { get; set; }
    }
}
