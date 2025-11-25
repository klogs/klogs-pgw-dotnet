using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model.CardPayment
{
    public class CommissionResponse: Response
    {
        public List<CardPaymentOption> Installments { get; set; } = new List<CardPaymentOption>();
    }

    public class CardPaymentOption
    {
        public string Title { get; set; }

        public string IssuerCode { get; set; }

        public string CardProgram { get; set; }

        public List<CardPaymentOptionCommRate> Installments { get; set; } = new List<CardPaymentOptionCommRate>();
    }

    public class CardPaymentOptionCommRate
    {
        public decimal CommRate { get; set; }

        public int Installment { get; set; }

        public string PaymentProviderId { get; set; }

        public Guid PaymentSystemId { get; set; }

        public int? PlusInstallment { get; set; }

        public int? PaymentDeferral { get; set; }

        public CommApplyType CommApplyType { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal NetAmount { get; set; }

        public string CardProgram { get; set; }
    }
}
