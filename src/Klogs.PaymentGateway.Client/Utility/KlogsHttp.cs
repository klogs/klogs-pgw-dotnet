using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Klogs.PaymentGateway.Client.Utility
{
    internal static class KlogsHttp
    {
        private static HttpClient _httpClient;

        private static object _lock = new object();

        public static string CreateRandomString()
        {
            var generator = RandomNumberGenerator.Create();

            var bytes = new byte[32];
            generator.GetBytes(bytes, 0, 32);

            return Regex.Replace(Convert.ToBase64String(bytes), "[/+=]", string.Empty);
        }

        public static string CreateHash(string text, string password)
        {
            using (var alg = new HMACSHA256(Encoding.UTF8.GetBytes(password)))
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);

                return Convert.ToBase64String(alg.ComputeHash(textBytes));
            }
        }

        internal static HttpClient GetOrCreate(string endpoint, string apiKey, string secretKey, Dictionary<string, string> additionalHeaders)
        {
            Monitor.Enter(_lock);

            if (_httpClient == null)
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(endpoint)
                };

                var randomString = CreateRandomString();
                var timestamp = DateTime.UtcNow.Ticks.ToString();

                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Api-Key", apiKey);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Rnd", randomString);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Timestamp", timestamp);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Klogs-Signature", CreateHash(string.Concat(apiKey, randomString, timestamp), secretKey));

                if (additionalHeaders != null)
                {
                    foreach (var header in additionalHeaders)
                    {
                        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }
            }

            Monitor.Exit(_lock);

            return _httpClient;
        }
    }
}
