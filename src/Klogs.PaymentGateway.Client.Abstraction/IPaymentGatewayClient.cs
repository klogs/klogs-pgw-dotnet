using System;

namespace Klogs.PaymentGateway.Client.Abstraction
{
    public interface IPaymentGatewayClient : IDisposable
    {
        ICardPaymentHttpClient CardPayment { get; }

        IHostedPaymentHttpClient HostedPayment { get; }

        IPaymentChannelHttpClient PaymentChannel { get; }

        IPaymentSystemGroupHttpClient PaymentSystemGroup { get; }

        IPaymentSystemHttpClient PaymentSystem { get; }

        IPaymentTransactionHttpClient Transaction { get; }
    }
}
