using System;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public interface IHandler
    {
        public ICredentials Handle(CredentialContainer container);
    }
    
    public interface IHandlerList
    {
        public ICredentials Handle(CredentialContainer container);
    }
}