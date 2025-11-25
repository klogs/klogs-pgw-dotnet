namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class TransactionDetailResponse : Response
    {
        public PaymentTransactionDetail Transaction { get; set; }
    }
}
