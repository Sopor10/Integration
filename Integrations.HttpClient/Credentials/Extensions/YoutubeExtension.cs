namespace Integrations.HttpClient.Credentials.Extensions
{
    public static class YoutubeExtension
    {
        public static ICredentials Youtube(this IServiceIntegrations integration, string apiKey)
        {
            return new QueryParameterAuthProvider().FromLiteral("key", apiKey);
        }
    }
}