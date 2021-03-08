using Newtonsoft.Json;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    internal class YoutubeApiKeyHandler : IHandler
    {
        public QueryParameterAuthProvider QueryParameterAuthProvider { get; }

        public YoutubeApiKeyHandler(QueryParameterAuthProvider queryParameterAuthProvider)
        {
            QueryParameterAuthProvider = queryParameterAuthProvider;
        }
        public ICredentials Handle(string fileContent)
        {
            var container = JsonConvert.DeserializeObject<CredentialContainer>(fileContent);

            if (container.Type != "youtube-api-key")
            {
                return null;
            }

            return QueryParameterAuthProvider.FromJson(container.Credential);
        }
    }
}