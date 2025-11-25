namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class Commission
    {
        public bool Enabled { get; set; }

        public int? Installment { get; set; }

        public decimal CommRate { get; set; }

        public int? PlusInstallment { get; set; }

        public int? PaymentDeferral { get; set; }

        public string Code { get; set; }

        public CommissionConstraint Constraint { get; set; }
    }
}
