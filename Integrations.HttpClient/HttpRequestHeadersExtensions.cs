using System.Net.Http.Headers;
using Integrations.HttpClient.Url.Header;

namespace Integrations.HttpClient
{
    public static class HttpRequestHeadersExtensions
    {
        public static void Add(this HttpRequestHeaders httpRequestHeaders, HeaderParameterList list)
        {
            foreach (var headerParameter in list.Values)
            {
                httpRequestHeaders.Add(headerParameter);
            }
        }
        public static void Add(this HttpRequestHeaders httpRequestHeaders, HeaderParameter parameter)
        {
            var (key, value) = parameter;
            httpRequestHeaders.Add(key,value.ToString());
        }
    }
}