using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    [Flags]
    public enum CardBrand
    {
        Unknown = 1,

        Visa = 2,
        Mastercard = 4,
        Amex = 8,
        Maestro = 16,
        Discover = 32,
        Troy = 64,
        JCB = 128,
        UnionPay = 256,
        DinnersClub = 512,
        EBT = 1024,
    }
}
