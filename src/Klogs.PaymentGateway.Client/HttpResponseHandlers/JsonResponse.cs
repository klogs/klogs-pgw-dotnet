using Klogs.PaymentGateway.Client.Abstraction.Model;
using Newtonsoft.Json;

namespace Klogs.PaymentGateway.Client.HttpResponseHandlers
{
    internal static class JsonResponse<T> where T : Response, new()
    {
        public static readonly HttpResponseHandler<T> Handler = new HttpResponseHandler<T>(async response =>
        {
            var content = await response.Content.ReadAsStringAsync();

            if(string.IsNullOrWhiteSpace(content))
            {
                return new T();
            }

            return JsonConvert.DeserializeObject<T>(content, KlogsHttpClient.JsonOptions);
        });
    }
}
