using System;
using System.Text;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class Error
    {
        public static Error New(string summary, object errorObject = null)
        {
            return new Error
            {
                Summary = summary,
                ErrorObject = errorObject
            };
        }

        public string Summary { get; set; }

        public object ErrorObject { get; set; }

        public virtual string ToBase64()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Summary));
        }
    }
}
