using System.IO;
using System.Threading.Tasks;

namespace Integrations.HttpClient.Credentials.Extensions
{
    public static class Openfaas
    {
        public static async Task<BasicAuth> FromOpenfaasSecret(this BasicAuthProvider provider, string secretName)
        {
            var userPassword = await File.ReadAllTextAsync("/var/openfaas/secrets/" + secretName);
            return provider.FromLiteral(userPassword);
        }
        
        public static async Task<BasicAuth> FromOpenfaasSecret(this BasicAuthProvider provider, string usernameSecret, string passwordSecret)
        {
            var user = await File.ReadAllTextAsync("/var/openfaas/secrets/" + usernameSecret);
            var password = await File.ReadAllTextAsync("/var/openfaas/secrets/" + passwordSecret);
            return provider.FromLiteral(user,password);
        }
    }

    public static class YoutubeExtension
    {
        public static ICredentials Youtube(this IServiceIntegrations integration, string apiKey)
        {
            return new QueryParameterAuthProvider().FromLiteral("key", apiKey);
        }
    }
    
    
}