namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public interface IHandler
    {
        public ICredentials? Handle(string container);
    }
}