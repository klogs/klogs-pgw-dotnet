using System;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentGatewayClient : IDisposable
    {
        ICardPaymentHttpClient CardPayment { get; }

        IHostedPaymentHttpClient HostedPayment { get; }

        IPaymentTransactionHttpClient Transaction { get; }
    }
}
