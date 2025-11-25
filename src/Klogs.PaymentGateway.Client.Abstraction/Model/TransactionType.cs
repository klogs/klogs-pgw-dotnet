namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public enum TransactionType
    {
        Sale = 1,

        Void = 2,

        Refund = 3,

        Provision = 4,

        ProvisionCommit = 5
    }
}
