using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public sealed class CreditCard : IEqualityComparer<CreditCard>
    {
        public string CardNumber { get; set; }

        public string Cvv { get; set; }

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }

        public string CardHolderName { get; set; }

        private static bool TryGetNormalizeCardNumber(string cardNumber, out string normalizedCardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                normalizedCardNumber = cardNumber;
                return false;
            }

            normalizedCardNumber = cardNumber.Replace(" ", "");
            return true;
        }

        public bool Equals(CreditCard x, CreditCard y)
        {
            return TryGetNormalizeCardNumber(x.CardNumber, out var xNumber) && TryGetNormalizeCardNumber(y.CardNumber, out var yNumer) && xNumber == yNumer;
        }

        public int GetHashCode(CreditCard obj)
        {
            return $"{obj.CardNumber}-{obj.ExpireMonth}-{obj.ExpireYear}-{obj.Cvv}".GetHashCode();
        }
    }
}
