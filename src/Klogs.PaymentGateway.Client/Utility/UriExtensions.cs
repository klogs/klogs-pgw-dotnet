using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    internal static class UriExtensions
    {
        private static char[] pathSeperator = new[] { '/' };
        private static char[] queryStringSeperator = new[] { '?' };
        private static char[] equalOperatorSeperator = new[] { '=' };
        private static char[] ampOperatorSeperator = new[] { '&' };

        public static Uri ToUri(this string stringUri)
        {
            return new Uri(stringUri, UriKind.RelativeOrAbsolute);
        }

        public static Uri AsRoot(this Uri uri)
        {
            return uri.IsAbsoluteUri
                     ? new Uri(uri.Scheme + "://" + uri.Authority)
                     : new Uri("", UriKind.RelativeOrAbsolute);
        }

        public static Uri Merge(this Uri uri, string relative)
        {
            var splitted = relative.Split(queryStringSeperator);

            if (splitted.Length > 0)
            {
                uri = uri.AddPath(splitted[0]);
            }

            if (splitted.Length == 2)
            {
                var qs = splitted[1].Split(ampOperatorSeperator, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x =>
                                    {
                                        var s = x.Split(equalOperatorSeperator);

                                        return new { key = s[0], val = s.Length > 1 ? s[1] : string.Empty };
                                    })
                                    .ToDictionary(x => x.key, x => x.val);

                uri = uri.AddQuery(qs);
            }

            return uri;
        }


        public static Uri AddPath(this Uri uri, string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (uri.IsAbsoluteUri)
            {
                var b = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(uri.UserInfo))
                {
                    b.Append(uri.UserInfo);
                    b.Append('@');
                }

                b.Append(uri.Scheme);
                b.Append("://");
                b.Append(uri.Authority);

                if (uri.Segments != null)
                {
                    var currentSegments = uri.Segments.Select(x => x.Replace("/", "")).Where(x => !string.IsNullOrWhiteSpace(x));

                    if (currentSegments.Any())
                    {
                        b.Append("/" + string.Join("/", currentSegments));
                    }
                }

                path.Split(pathSeperator, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(segment => b.Append($"/{segment}"));

                if (uri.Query != null)
                {
                    b.Append(uri.Query);
                }

                return new Uri(b.ToString());
            }
            else
            {
                var segments = GetSegmetsFromRelativeUri(uri);

                path.Split(pathSeperator, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(segment => segments.Add(segment));

                var query = GetQueryFromRelativeUri(uri);

                if (query.Any())
                {
                    return $"{string.Join("/", segments)}?{string.Join("&", query.Select(x => $"{x.Key}={x.Value}"))}".ToUri();
                }

                return string.Join("/", segments).ToUri();
            }
        }

        public static Uri AddQuery(this Uri uri, string key, params string[] values)
        {
            return AddQuery(uri, key, ignoreNullValues: false, values: values);
        }

        public static Uri AddQuery(this Uri uri, IDictionary<string, string> query)
        {
            return AddQuery(uri, query: query, ignoreNullValues: false);
        }

        public static Uri AddQuery(this Uri uri, object query)
        {
            return AddQuery(uri, query: query, ignoreNullValues: false);
        }

        public static Uri AddQuery(this Uri uri, string key, bool ignoreNullValues, params string[] values)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (ignoreNullValues)
            {
                values = values.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }

            var b = new StringBuilder();

            if (uri.IsAbsoluteUri)
            {
                if (!string.IsNullOrWhiteSpace(uri.UserInfo))
                {
                    b.Append(uri.UserInfo);
                    b.Append('@');
                }

                b.Append(uri.Scheme);
                b.Append("://");
                b.Append(uri.Authority);

                if (uri.Segments != null)
                {
                    var currentSegments = uri.Segments.Select(x => x.Replace("/", "")).Where(x => !string.IsNullOrWhiteSpace(x));

                    if (currentSegments.Any())
                    {
                        b.Append("/" + string.Join("/", currentSegments));
                    }
                }

                if (!string.IsNullOrWhiteSpace(uri.Query))
                {
                    b.Append(uri.Query);
                    b.Append("&");
                }
                else
                {
                    b.Append("?");
                }

                b.Append(string.Join("&", values.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => $"{key}={x}")));

                return new Uri(b.ToString());
            }
            else
            {
                var segments = GetSegmetsFromRelativeUri(uri);

                var queryString = uri.GetQueryFromRelativeUri()
                                     .ToList();

                foreach (var q in values.Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    queryString.Add(new KeyValuePair<string, string>(key, q));
                }

                return $"{string.Join("/", segments)}?{string.Join("&", queryString.Select(x => $"{x.Key}={x.Value}"))}".ToUri();
            }
        }

        public static Uri AddQuery(this Uri uri, IDictionary<string, string> query, bool ignoreNullValues)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (ignoreNullValues)
            {
                query = query.Where(x => !string.IsNullOrWhiteSpace(x.Value)).ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            }

            var b = new StringBuilder();

            if (uri.IsAbsoluteUri)
            {
                if (!string.IsNullOrWhiteSpace(uri.UserInfo))
                {
                    b.Append(uri.UserInfo);
                    b.Append('@');
                }

                b.Append(uri.Scheme);
                b.Append("://");
                b.Append(uri.Authority);

                if (uri.Segments != null)
                {
                    var currentSegments = uri.Segments.Select(x => x.Replace("/", "")).Where(x => !string.IsNullOrWhiteSpace(x));

                    if (currentSegments.Any())
                    {
                        b.Append("/" + string.Join("/", currentSegments));
                    }
                }

                if (!string.IsNullOrWhiteSpace(uri.Query))
                {
                    b.Append(uri.Query);
                    b.Append("&");
                    b.Append(string.Join("&", query.Select(x => $"{x.Key}={x.Value}")));
                }
                else
                {
                    b.Append("?");
                    b.Append(string.Join("&", query.Select(x => $"{x.Key}={x.Value}")));
                }

                return new Uri(b.ToString());
            }
            else
            {
                var segments = GetSegmetsFromRelativeUri(uri);

                var queryString = uri.GetQueryFromRelativeUri()
                                     .ToList();

                foreach (var q in query)
                {
                    queryString.Add(new KeyValuePair<string, string>(q.Key, q.Value));
                }

                return $"{string.Join("/", segments)}?{string.Join("&", queryString.Select(x => $"{x.Key}={x.Value}"))}".ToUri();
            }
        }

        public static Uri AddQuery(this Uri uri, object query, bool ignoreNullValues)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var parameters = query.GetType()
                                  .GetProperties()
                                  .ToDictionary(x => x.Name, x => $"{x.GetValue(query)}");

            return AddQuery(uri, parameters, ignoreNullValues);
        }

        public static Uri WithoutQuery(this Uri uri)
        {
            return new Uri(uri.AbsoluteUri.Split(queryStringSeperator)[0]);
        }

        public static string GetQueryValue(this Uri uri, string key)
        {
            var qs = uri.ToString()
                        .Split(queryStringSeperator);

            if (qs.Length < 2)
            {
                return null;
            }

            var qsarr = qs[1].Split(ampOperatorSeperator).Select(x =>
            {

                var kv = x.Split(equalOperatorSeperator);

                return new
                {
                    Key = kv[0],
                    Value = kv.Length > 1 ? kv[1] : null
                };
            });

            return qsarr.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase))?.Value;
        }

        private static List<string> GetSegmetsFromRelativeUri(Uri uri)
        {
            var stringUri = uri.ToString();

            int querySeperatorIndex = stringUri.IndexOf("?");

            return (querySeperatorIndex == -1 ? stringUri : stringUri.Substring(0, querySeperatorIndex))
                            .Split(pathSeperator, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
        }

        public static IEnumerable<KeyValuePair<string, string>> GetQueryFromRelativeUri(this Uri uri)
        {
            var stringUri = uri.ToString();

            int querySeperatorIndex = stringUri.IndexOf("?");

            if (querySeperatorIndex == -1)
            {
                return Enumerable.Empty<KeyValuePair<string, string>>();
            }

            return stringUri.Substring(querySeperatorIndex + 1, stringUri.Length - 1 - querySeperatorIndex)
                            .Split(ampOperatorSeperator, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => new KeyValuePair<string, string>(x.Split(equalOperatorSeperator)[0], x.Split(equalOperatorSeperator)[1]));
        }
    }
}