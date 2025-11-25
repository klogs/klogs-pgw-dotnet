namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class Response<T> : Response
    {
        public T Value { get; set; }
    }

    public class Response
    {
        public virtual bool Success => Error == null;

        public Error Error { get; set; }

        public static Response CreateSuccess()
        {
            return new Response
            {
                Error = null
            };
        }

        public static Response<T> CreateSuccess<T>()
        {
            return new Response<T>
            {
                Error = null,
            };
        }

        public static Response<T> CreateSuccess<T>(T data)
        {
            return new Response<T>
            {
                Value = data
            };
        }

        public static Response CreateFail(string summary)
        {
            return new Response
            {
                Error = Error.New(summary)
            };
        }

        public static Response<T> CreateFail<T>(string summary)
        {
            return new Response<T>
            {
                Error = Error.New(summary)
            };
        }
    }
}