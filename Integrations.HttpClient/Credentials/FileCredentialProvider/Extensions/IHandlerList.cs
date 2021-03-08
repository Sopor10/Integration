namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public interface IHandlerList
    {
        public ICredentials Handle(string container);
    }
}