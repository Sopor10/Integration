namespace Integrations.HttpClient.Credentials
{
    public class CredentialProvider
    {
        public BasicAuthProvider BasicAuth => new();
        public  ICredentials None => new NoCredentials();
        public IServiceIntegrations For => new ServiceIntegrations();
    }

    public interface IServiceIntegrations
    {
    }

    public class ServiceIntegrations : IServiceIntegrations
    {
    }
}