using System;
using System.Collections.Generic;
using System.Linq;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public struct CurrencyType
    {
        private static readonly Lazy<List<CurrencyType>> _currencies = new Lazy<List<CurrencyType>>(valueFactory: () =>
        {
            return new List<CurrencyType>
            {
                new CurrencyType("AED", 784), new CurrencyType("AFN", 971), new CurrencyType("ALL", 8),
                new CurrencyType("AMD", 51), new CurrencyType("ANG", 532), new CurrencyType("AOA", 973),
                new CurrencyType("ARS", 32), new CurrencyType("AUD", 36), new CurrencyType("AWG", 533),
                new CurrencyType("AZN", 944), new CurrencyType("BAM", 977), new CurrencyType("BBD", 52),
                new CurrencyType("BDT", 50), new CurrencyType("BGN", 975), new CurrencyType("BHD", 48),
                new CurrencyType("BIF", 108), new CurrencyType("BMD", 60), new CurrencyType("BND", 96),
                new CurrencyType("BOB", 68), new CurrencyType("BOV", 984), new CurrencyType("BRL", 986),
                new CurrencyType("BSD", 44), new CurrencyType("BTN", 64), new CurrencyType("BWP", 72),
                new CurrencyType("BYR", 974), new CurrencyType("BZD", 84), new CurrencyType("CAD", 124),
                new CurrencyType("CDF", 976), new CurrencyType("CHE", 947), new CurrencyType("CHF", 756),
                new CurrencyType("CHW", 948), new CurrencyType("CLF", 990), new CurrencyType("CLP", 152),
                new CurrencyType("CNY", 156), new CurrencyType("COP", 170), new CurrencyType("COU", 970),
                new CurrencyType("CRC", 188), new CurrencyType("CUC", 931), new CurrencyType("CUP", 192),
                new CurrencyType("CVE", 132), new CurrencyType("CZK", 203), new CurrencyType("DJF", 262),
                new CurrencyType("DKK", 208), new CurrencyType("DOP", 214), new CurrencyType("DZD", 12),
                new CurrencyType("EGP", 818), new CurrencyType("ERN", 232), new CurrencyType("ETB", 230),
                new CurrencyType("EUR", 978), new CurrencyType("FJD", 242), new CurrencyType("FKP", 238),
                new CurrencyType("GBP", 826), new CurrencyType("GEL", 981), new CurrencyType("GHS", 936),
                new CurrencyType("GIP", 292), new CurrencyType("GMD", 270), new CurrencyType("GNF", 324),
                new CurrencyType("GTQ", 320), new CurrencyType("GYD", 328), new CurrencyType("HKD", 344),
                new CurrencyType("HNL", 340), new CurrencyType("HRK", 191), new CurrencyType("HTG", 332),
                new CurrencyType("HUF", 348), new CurrencyType("IDR", 360), new CurrencyType("ILS", 376),
                new CurrencyType("INR", 356), new CurrencyType("IQD", 368), new CurrencyType("IRR", 364),
                new CurrencyType("ISK", 352), new CurrencyType("JMD", 388), new CurrencyType("JOD", 400),
                new CurrencyType("JPY", 392), new CurrencyType("KES", 404), new CurrencyType("KGS", 417),
                new CurrencyType("KHR", 116), new CurrencyType("KMF", 174), new CurrencyType("KPW", 408),
                new CurrencyType("KRW", 410), new CurrencyType("KWD", 414), new CurrencyType("KYD", 136),
                new CurrencyType("KZT", 398), new CurrencyType("LAK", 418), new CurrencyType("LBP", 422),
                new CurrencyType("LKR", 144), new CurrencyType("LRD", 430), new CurrencyType("LSL", 426),
                new CurrencyType("LTL", 440), new CurrencyType("LVL", 428), new CurrencyType("LYD", 434),
                new CurrencyType("MAD", 504), new CurrencyType("MDL", 498), new CurrencyType("MGA", 969),
                new CurrencyType("MKD", 807), new CurrencyType("MMK", 104), new CurrencyType("MNT", 496),
                new CurrencyType("MOP", 446), new CurrencyType("MRO", 478), new CurrencyType("MUR", 480),
                new CurrencyType("MVR", 462), new CurrencyType("MWK", 454), new CurrencyType("MXN", 484),
                new CurrencyType("MXV", 979), new CurrencyType("MYR", 458), new CurrencyType("MZN", 943),
                new CurrencyType("NAD", 516), new CurrencyType("NGN", 566), new CurrencyType("NIO", 558),
                new CurrencyType("NOK", 578), new CurrencyType("NPR", 524), new CurrencyType("NZD", 554),
                new CurrencyType("OMR", 512), new CurrencyType("PAB", 590), new CurrencyType("PEN", 604),
                new CurrencyType("PGK", 598), new CurrencyType("PHP", 608), new CurrencyType("PKR", 586),
                new CurrencyType("PLN", 985), new CurrencyType("PYG", 600), new CurrencyType("QAR", 634),
                new CurrencyType("RON", 946), new CurrencyType("RSD", 941), new CurrencyType("RUB", 643),
                new CurrencyType("RWF", 646), new CurrencyType("SAR", 682), new CurrencyType("SBD", 90),
                new CurrencyType("SCR", 690), new CurrencyType("SDG", 938), new CurrencyType("SEK", 752),
                new CurrencyType("SGD", 702), new CurrencyType("SHP", 654), new CurrencyType("SLL", 694),
                new CurrencyType("SOS", 706), new CurrencyType("SRD", 968), new CurrencyType("SSP", 728),
                new CurrencyType("STD", 678), new CurrencyType("SYP", 760), new CurrencyType("SZL", 748),
                new CurrencyType("THB", 764), new CurrencyType("TJS", 972), new CurrencyType("TMT", 934),
                new CurrencyType("TND", 788), new CurrencyType("TOP", 776), new CurrencyType("TRY", 949),
                new CurrencyType("TTD", 780), new CurrencyType("TWD", 901), new CurrencyType("TZS", 834),
                new CurrencyType("UAH", 980), new CurrencyType("UGX", 800), new CurrencyType("USD", 840),
                new CurrencyType("USN", 997), new CurrencyType("USS", 998), new CurrencyType("UYI", 940),
                new CurrencyType("UYU", 858), new CurrencyType("UZS", 860), new CurrencyType("VEF", 937),
                new CurrencyType("VND", 704), new CurrencyType("VUV", 548), new CurrencyType("WST", 882),
                new CurrencyType("XAF", 950), new CurrencyType("XCD", 951), new CurrencyType("XOF", 952),
                new CurrencyType("XPF", 953), new CurrencyType("YER", 886), new CurrencyType("ZAR", 710),
                new CurrencyType("ZMW", 967)
            };
        });

        private CurrencyType(string iso, int number)
        {
            Iso4217 = iso;
            Number = number;
        }

        public string Iso4217 { get; private set; }

        public int Number { get; private set; }

        public bool IsValid
        {
            get { return Iso4217 == null && Number != 0; }
        }


        public readonly static CurrencyType Empty = new CurrencyType { Iso4217 = null, Number = 0 };

        public static CurrencyType FromNumber(int number)
        {
            var c = _currencies.Value.FirstOrDefault(x => x.Number == number);

            if (c == null)
            {
                return Empty;
            }

            return c;
        }

        public static CurrencyType FromISO4217(string iso4217)
        {
            var c = _currencies.Value.FirstOrDefault(x => x.Iso4217 == iso4217);

            if (c == null)
            {
                return Empty;
            }

            return c;
        }

        public static CurrencyType[] Currencies => _currencies.Value.ToArray();

        public override string ToString()
        {
            return Iso4217;
        }

        public override int GetHashCode()
        {
            return $"{Iso4217}{Number}".GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CurrencyType currency)
            {
                return currency.Number == Number;
            }

            return false;
        }


        public static implicit operator CurrencyType(string value)
        {
            return _currencies.Value.Find(x => x.Iso4217 == value);
        }


        public static implicit operator CurrencyType(int number)
        {
            return _currencies.Value.Find(x => x.Number == number);
        }

        public static bool operator !=(CurrencyType left, CurrencyType right)
        {
            return !(left == right);
        }

        public static bool operator ==(CurrencyType left, CurrencyType right)
        {
            return left.Iso4217 == right.Iso4217;
        }
    }
}
