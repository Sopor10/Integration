using System.Linq;
using System.Net.Http;
using Integrations.HttpClient.Url.QueryParameter;

namespace Integrations.HttpClient.Credentials
{
    public record QueryParameterAuth(QueryParameter Parameter):ICredentials
    {
        public IClient Authorize(IClient client)
        {
            return client.AddQueryParameter(Parameter);
        }
    }

    public class QueryParameterAuthProvider
    {
        public QueryParameterAuth FromLiteral(string key, string parameter) =>
            new(new QueryParameter(key, parameter));
    }
}