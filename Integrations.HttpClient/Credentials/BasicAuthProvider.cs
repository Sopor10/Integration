using Newtonsoft.Json.Linq;

namespace Integrations.HttpClient.Credentials
{
    public record BasicAuthProvider
    {
        public BasicAuth FromLiteral(string user, string password) => new(user, password);
        public BasicAuth FromLiteral(string userPassword)
        {
            var seperatorIndex = userPassword.IndexOf(':');
            var user = userPassword.Substring(0, seperatorIndex);
            var password = userPassword.Substring(seperatorIndex + 1);
            return new(user, password);
        }

        public BasicAuth FromJson(JObject json) => json.ToObject<BasicAuth>();
    }
}