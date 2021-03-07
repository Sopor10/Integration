using System.Collections;
using System.Collections.Generic;
using System.IO;
using Integrations.HttpClient.Credentials;
using Integrations.HttpClient.Credentials.FileCredentialProvider;
using Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Integrations.HttpClient
{
    public static class Startup
    {
        public static IServiceCollection InstallHttpClient(this IServiceCollection services,DirectoryInfo secretDirectory = null)
        {
            if (secretDirectory == null)
            {
                secretDirectory = new DirectoryInfo("C:/dev/Integrations/Credentials");
            }
            
            services.AddTransient<IClient, Client>();
            services.AddTransient<IServiceIntegrations, ServiceIntegrations>();
            services.AddTransient<ISecretReader, SecretReader>();
            services.AddTransient<CredentialProvider>();
            services.AddTransient<BasicAuthProvider>();
            services.AddTransient<QueryParameterAuthProvider>();
            services.AddTransient(x => new Config()
            {
                SecrectDirectory = secretDirectory
            });
            
            services.AddTransient<IHandler, OpenfaasHandler>();
            services.AddTransient<IHandler, YoutubeApiKeyHandler>();
            services.AddTransient<IHandlerList, HandlerList>();
            
            return services;
        }
    }
}