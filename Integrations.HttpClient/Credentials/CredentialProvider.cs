using Integrations.HttpClient.Credentials.FileCredentialProvider;

namespace Integrations.HttpClient.Credentials
{
    public class CredentialProvider
    {
        public CredentialProvider(BasicAuthProvider basicAuth, IServiceIntegrations @for, ISecretReader file)
        {
            BasicAuth = basicAuth;
            For = @for;
            File = file;
        }

        public BasicAuthProvider BasicAuth { get; }
        public ICredentials None { get; } = new NoCredentials();
        public IServiceIntegrations For { get; }
        public ISecretReader File { get; }
    }
}