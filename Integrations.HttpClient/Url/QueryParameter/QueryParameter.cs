using System.Net.Http.Headers;

namespace Integrations.HttpClient.Url.QueryParameter
{
    public record QueryParameter(string Key, object Value)
    {
        public override string ToString() => $"{Key}={Value}";
    }

}