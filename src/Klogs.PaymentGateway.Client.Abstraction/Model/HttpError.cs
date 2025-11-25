using System.Net;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class HttpError : Error
    {
        public static HttpError New(HttpStatusCode statusCode)
        {
            return New(statusCode.ToString(), statusCode);
        }

        public static HttpError New(string summary, HttpStatusCode statusCode)
        {
            return new HttpError(summary, statusCode);
        }

        public HttpError()
        {

        }

        public HttpError(HttpStatusCode statusCode) : this(statusCode.ToString(), statusCode)
        {

        }

        public HttpError(string summary, HttpStatusCode statusCode)
        {
            Summary = summary;
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
