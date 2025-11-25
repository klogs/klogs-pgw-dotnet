using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.Transaction
{
    public class PaymentTransaction : PaymentTransactionBase
    {
        public Guid Id { get; set; }

        public decimal Balance { get; set; }

        public string ClientReferenceCode { get; set; }

        public decimal CommissionRate { get; set; }

        public string CurrencyCode { get; set; }

        public string PaymentProviderId { get; set; }

        public decimal? RewardAmount { get; set; }

        public int? PlusInstallment { get; set; }

        public int? PaymentDeferral { get; set; }

        public int? Installment { get; set; }

        public string OrderId { get; set; }

        public string PaymentMethod { get; set; }

        public NameCodeModel Application { get; set; }

        public TransactionUser User { get; set; }

        public NameCodeModel PaymentSystem { get; set; }

        public IEnumerable<NameValueModel> PaymentItems { get; set; }

        public IEnumerable<NameValueModel> Fields { get; set; }
    }

    public class NameCodeModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class TransactionError
    {
        public string Error { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }

    public class TransactionUser
    {
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
