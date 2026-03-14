# Klogs Payment Gateway — .NET Client

A lightweight .NET client library for integrating with the [Klogs Payment Gateway](https://pgw.klogs.io).

---

## Installation

Install the NuGet package:

```bash
dotnet add package Klogs.PaymentGateway.Client
```

---

## Quick Start

```csharp
using Klogs.PaymentGateway.Client;

using var client = new PaymentGatewayClient(
    endpoint:  "https://pgw.klogs.io",
    apiKey:    "your-api-key",
    secretKey: "your-secret-key"
);
```

Or inject an existing `HttpClient`:

```csharp
using var client = new PaymentGatewayClient(httpClient);
```

---

## Services

`PaymentGatewayClient` exposes three service groups:

| Property          | Interface                      | Description                             |
|-------------------|--------------------------------|-----------------------------------------|
| `CardPayment`     | `ICardPaymentHttpClient`       | Direct card (3-D Secure / non-3DS) payments |
| `HostedPayment`   | `IHostedPaymentHttpClient`     | Redirect-based hosted payment page      |
| `Transaction`     | `IPaymentTransactionHttpClient`| Query, void, and refund transactions    |

---

## Card Payment

### 1. Create a Payment Token

Before charging a card you must obtain a one-time payment token:

```csharp
var tokenResponse = await client.CardPayment.CreatePaymentTokenAsync();
string token = tokenResponse.Value.Token;
```

### 2. Charge a Card

```csharp
var request = new CardPaymentRequest
{
    Token         = token,
    Amount        = 150.00m,
    Currency      = "TRY",
    ReferenceCode = "ORDER-001",
    Use3d         = true,
    ReturnURL     = "https://yoursite.com/payment/callback",
    Email         = "customer@example.com",
    Card = new CreditCard
    {
        CardNumber      = "4111111111111111",
        CardHolderName  = "John Doe",
        ExpireMonth     = "12",
        ExpireYear      = "2030",
        Cvv             = "123"
    }
};

var response = await client.CardPayment.PayAsync(request);

if (response.Success)
{
    // For 3-D Secure flows, redirect the user to response.Link
    Console.WriteLine(response.Link);
}
else
{
    Console.WriteLine(response.Error.Summary);
}
```

### 3. Commit a Provision

```csharp
var commitResponse = await client.CardPayment.ProvisionCommitAsync(new ProvisionCommitRequest
{
    ReferenceCode = "ORDER-001"
});
```

### 4. Get Installment Commissions by BIN

```csharp
var commissions = await client.CardPayment.CommissionsByBinAsync(new CommissionsRequest
{
    BinNumber = "411111",
    Amount    = 300.00m,
    Currency  = CurrencyType.TRY
});
```

---

## Hosted Payment

Redirect the customer to a Klogs-hosted payment page:

```csharp
var hostedRequest = new HostedPaymentRequest
{
    Amount        = 250.00m,
    Currency      = "TRY",
    Reference     = "ORDER-002",
    FullName      = "Jane Doe",
    Email         = "jane@example.com",
    Phone         = "+905551234567",
    ReturnURL     = "https://yoursite.com/payment/callback",
    Explanation   = "Order #ORDER-002"
};

var hostedResponse = await client.HostedPayment.CreatePayment(hostedRequest);

// Redirect your customer to hostedResponse.Url
```

---

## Transaction Management

### List Transactions

```csharp
var list = await client.Transaction.ListAsync(new TransactionPageQuery
{
    Page = 1,
    PageSize = 20
});
```

### Get Transaction Detail

```csharp
var detail = await client.Transaction.DetailAsync("ORDER-001");
```

### Void a Transaction

```csharp
var voidResponse = await client.Transaction.VoidAsync(new VoidRequest
{
    ReferenceCode = "ORDER-001"
});
```

### Refund a Transaction

```csharp
var refundResponse = await client.Transaction.RefundAsync(new RefundRequest
{
    ReferenceCode = "ORDER-001"
});
```

---

## Dependency Injection (ASP.NET Core)

You can register the client with the built-in DI container and `IHttpClientFactory`:

```csharp
builder.Services.AddHttpClient<IPaymentGatewayClient, PaymentGatewayClient>(client =>
{
    client.BaseAddress = new Uri("https://pgw.klogs.io");

    var randomString = Guid.NewGuid().ToString();
    var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

    var signature = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)).ComputeHash(Encoding.UTF8.GetBytes(string.Concat(apiKey, randomString, timestamp)));

    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Api-Key", apiKey);
    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Rnd", randomString);
    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Timestamp", timestamp);
    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Signature", signature);
});

//OR

builder.Services.AddScoped<IPaymentGatewayClient>(sp =>
{
    return new PaymentGatewayClient("api-key", "secret-key");
});
```

---

## Supported Frameworks

`Klogs.PaymentGateway.Client` targets **netstandard2.0** and is compatible with:

- .NET 6 / 8 / 10
- .NET Framework 4.6.2, 4.7, 4.8
- .NET Core 3.1

---

## License

See [LICENSE](LICENSE) for details.
