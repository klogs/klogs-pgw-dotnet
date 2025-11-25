namespace Klogs.PaymentGateway.Client.Abstraction.Model.PaymentInfrastructure
{
    public class CommissionConstraint
    {
        public CardType? CardType { get; set; }

        public CardBrand? CardBrand { get; set; }

        public bool? IsBusiness { get; set; }
    }
}
