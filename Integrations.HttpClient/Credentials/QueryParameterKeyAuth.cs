using Integrations.HttpClient.Url.QueryParameter;
using Newtonsoft.Json.Linq;

namespace Integrations.HttpClient.Credentials
{
    public record QueryParameterAuth(string Key, string Token):ICredentials
    {
        public IClient Authorize(IClient client)
        {
            return client.AddQueryParameter(new QueryParameter(Key, Token));
        }
    }

    public class QueryParameterAuthProvider
    {
        public QueryParameterAuth FromLiteral(string key, string parameter) =>
            new(key, parameter);
        public QueryParameterAuth FromJson(JObject json) => json.ToObject<QueryParameterAuth>();
    }
}