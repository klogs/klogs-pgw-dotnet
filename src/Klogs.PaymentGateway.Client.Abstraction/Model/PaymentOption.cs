using System;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    [Flags]
    public enum PaymentOption
    {
        Secure = 1,

        Direct = 2
    }
}
