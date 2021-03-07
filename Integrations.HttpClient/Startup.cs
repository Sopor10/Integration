using System.IO;
using Integrations.HttpClient.Credentials;
using Integrations.HttpClient.Credentials.FileCredentialProvider;
using Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Integrations.HttpClient
{
    public static class Startup
    {
        public static IServiceCollection InstallHttpClient(this IServiceCollection services,Config config = null)
        {
            if (config == null)
            {
                config = new Config();
            }
            
            services.AddTransient<IClient, Client>();
            services.AddTransient<IServiceIntegrations, ServiceIntegrations>();
            services.AddTransient<ISecretReader, SecretReader>();
            services.AddTransient<CredentialProvider>();
            services.AddTransient<BasicAuthProvider>();
            services.AddTransient<QueryParameterAuthProvider>();
            services.AddTransient(x => config);
            
            services.AddTransient<IHandler, OpenfaasHandler>();
            services.AddTransient<IHandler, YoutubeApiKeyHandler>();
            services.AddTransient<IHandlerList, HandlerList>();
            
            return services;
        }
    }
}