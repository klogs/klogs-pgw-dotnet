using Klogs.PaymentGateway.Client.Abstraction.Model;
using Klogs.PaymentGateway.Client.HttpResponseHandlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Klogs.PaymentGateway.Client
{
    public abstract class KlogsHttpClient
    {
        protected KlogsHttpClient(HttpClient client)
        {
            Client = client;
        }

        protected virtual HttpClient Client { get; }

        protected virtual ILogger Logger { get; } = new StandartOutputLogger();


        public readonly static JsonSerializerSettings JsonOptions = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.None
        };

        static KlogsHttpClient()
        {
            JsonOptions.Converters.Add(new StringEnumConverter());
        }


        private const string ApplicationJsonMediaType = "application/json";

        private static StringContent ToJson(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new StringContent(
                content: JsonConvert.SerializeObject(obj, JsonOptions),
                encoding: Encoding.UTF8,
                mediaType: ApplicationJsonMediaType);
        }

        private static HttpRequestMessage createRequest(HttpMethod method, string resourceUri, Dictionary<string, string[]> headers = null, object body = null)
        {
            var req = new HttpRequestMessage(method, resourceUri)
            {
                Content = ToJson(body)
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    req.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return req;
        }

        protected virtual async Task<T> GetAsync<T>(string resourceUri, HttpResponseHandler<T> responseHandler = null, Dictionary<string, string[]> headers = null, [CallerMemberName] string methodName = "") where T : Response, new()
        {
            Logger.LogInformation("{MethodName} request begin.", methodName);

            try
            {
                using (var httpResponse = await Client.SendAsync(createRequest(HttpMethod.Get, resourceUri, headers)))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var handler = responseHandler ?? JsonResponse<T>.Handler;

                        var responseObj = await handler(httpResponse);

                        Logger.LogDebug("{MethodName} request end. statusCode: {StatusCode}, {ResponseContent}, {ResponseObject}", methodName, httpResponse.StatusCode, responseObj);

                        return responseObj;
                    }

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    Logger.LogError("Error in {MethodName}. {ResponseContent}", methodName, content);

                    return new T
                    {
                        Error = HttpError.New($"Error in {methodName}", httpResponse.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception in {MethodName}.", methodName);

                return new T
                {
                    Error = Error.New($"Error in {methodName}")
                };
            }
        }

        protected virtual async Task<T> PostAsync<T>(string resourceUri, object body, HttpResponseHandler<T> responseHandler = null, Dictionary<string, string[]> headers = null, [CallerMemberName] string methodName = "") where T : Response, new()
        {
            Logger.LogInformation("{MethodName} request begin. {Uri}", methodName, resourceUri);

            try
            {
                using (var httpResponse = await Client.SendAsync(createRequest(HttpMethod.Post, resourceUri, headers, body)))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var handler = responseHandler ?? JsonResponse<T>.Handler;

                        var responseObj = await handler(httpResponse);

                        Logger.LogDebug("{MethodName} request end. statusCode: {StatusCode}, {ResponseContent}, {ResponseObject}", methodName, httpResponse.StatusCode, responseObj);

                        return responseObj;
                    }

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    Logger.LogError("Error in {MethodName}. {ResponseContent}", methodName, content);

                    return new T
                    {
                        Error = HttpError.New($"Error in {methodName}", httpResponse.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception in {MethodName}. {@Body}", methodName, body);

                return new T
                {
                    Error = Error.New($"Error in {methodName}")
                };
            }
        }

        protected virtual async Task<T> DeleteAsync<T>(string resourceUri, HttpResponseHandler<T> responseHandler = null, Dictionary<string, string[]> headers = null, [CallerMemberName] string methodName = "") where T : Response, new()
        {
            Logger.LogInformation("{MethodName} request begin.", methodName);

            try
            {
                using (var httpResponse = await Client.SendAsync(createRequest(HttpMethod.Delete, resourceUri, headers)))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var handler = responseHandler ?? JsonResponse<T>.Handler;

                        var responseObj = await handler(httpResponse);

                        Logger.LogDebug("{MethodName} request end. statusCode: {StatusCode}, {ResponseContent}, {ResponseObject}", methodName, httpResponse.StatusCode, responseObj);

                        return responseObj;
                    }

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    Logger.LogError("Error in {MethodName}. {ResponseContent}", methodName, content);

                    return new T
                    {
                        Error = HttpError.New($"Error in {methodName}", httpResponse.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception in {MethodName}.", methodName);

                return new T
                {
                    Error = Error.New($"Error in {methodName}")
                };
            }
        }

        protected virtual async Task<T> PutAsync<T>(string resourceUri, object body, HttpResponseHandler<T> responseHandler = null, Dictionary<string, string[]> headers = null, [CallerMemberName] string methodName = "") where T : Response, new()
        {
            Logger.LogInformation("{MethodName} request begin.", methodName);

            try
            {
                using (var httpResponse = await Client.SendAsync(createRequest(HttpMethod.Put, resourceUri, headers, body)))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var handler = responseHandler ?? JsonResponse<T>.Handler;

                        var responseObj = await handler(httpResponse);

                        Logger.LogDebug("{MethodName} request end. statusCode: {StatusCode}, {ResponseContent}, {ResponseObject}", methodName, httpResponse.StatusCode, responseObj);

                        return responseObj;
                    }

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    Logger.LogError("Error in {MethodName}. {ResponseContent}", methodName, content);

                    return new T
                    {
                        Error = HttpError.New($"Error in {methodName}", httpResponse.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Exception in {MethodName}. {@Body}", methodName, body);

                return new T
                {
                    Error = Error.New($"Error in {methodName}")
                };
            }
        }
    }
}
