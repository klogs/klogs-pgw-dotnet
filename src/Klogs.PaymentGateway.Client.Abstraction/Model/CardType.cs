using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    [Flags]
    public enum CardType
    {
        Credit = 1,
        Debit = 2,
        Prepaid = 4
    }
}