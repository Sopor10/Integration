using Newtonsoft.Json;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    internal class YoutubeApiKeyHandler :GenericHandler
    {
        public QueryParameterAuthProvider QueryParameterAuthProvider { get; }

        public YoutubeApiKeyHandler(QueryParameterAuthProvider queryParameterAuthProvider): base(new[]{"youtube-api-key"})
        {
            QueryParameterAuthProvider = queryParameterAuthProvider;
        }
        protected override ICredentials? Handle(CredentialContainer container)
        {
            return QueryParameterAuthProvider.FromJson(container.Credential);
        }
    }
}