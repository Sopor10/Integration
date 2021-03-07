namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    internal class OpenfaasHandler: IHandler
    {
        public BasicAuthProvider BasicAuthProvider { get; }

        public OpenfaasHandler(BasicAuthProvider basicAuthProvider)
        {
            BasicAuthProvider = basicAuthProvider;
        }
        public ICredentials Handle(CredentialContainer container)
        {
            
            if (container.Type != "openfaas")
            {
                return null;
            }

            return BasicAuthProvider.FromJson(container.Credential);
        }
    }
    
    internal class YoutubeApiKeyHandler : IHandler
    {
        public QueryParameterAuthProvider QueryParameterAuthProvider { get; }

        public YoutubeApiKeyHandler(QueryParameterAuthProvider queryParameterAuthProvider)
        {
            QueryParameterAuthProvider = queryParameterAuthProvider;
        }
        public ICredentials Handle(CredentialContainer container)
        {
            if (container.Type != "youtube-api-key")
            {
                return null;
            }

            return QueryParameterAuthProvider.FromJson(container.Credential);
        }
    }
}