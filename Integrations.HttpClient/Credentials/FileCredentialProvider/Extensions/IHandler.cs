﻿namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public interface IHandler
    {
        public ICredentials Handle(string container);
    }
    
    public interface IHandlerList
    {
        public ICredentials Handle(string container);
    }
}