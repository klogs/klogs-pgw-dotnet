using Klogs.PaymentGateway.Client.Abstraction.Model;
using Newtonsoft.Json;

namespace Klogs.PaymentGateway.Client.HttpResponseHandlers
{
    public static class GenericResponse<TValue>
    {
        public static readonly HttpResponseHandler<Response<TValue>> Handler = new HttpResponseHandler<Response<TValue>>(async response =>
        {
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                return new Response<TValue>();
            }

            var obj = JsonConvert.DeserializeObject<TValue>(content, KlogsHttpClient.JsonOptions);

            return new Response<TValue>
            {
                Value = obj
            };
        });
    }
}