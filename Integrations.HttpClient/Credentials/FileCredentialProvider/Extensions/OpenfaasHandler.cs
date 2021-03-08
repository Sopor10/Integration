namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    internal class OpenfaasHandler: GenericHandler
    {
        public BasicAuthProvider BasicAuthProvider { get; }

        public OpenfaasHandler(BasicAuthProvider basicAuthProvider) : base( new[]{"openfaas"})

        {
            BasicAuthProvider = basicAuthProvider;
        }

        protected override ICredentials? Handle(CredentialContainer container)
        {
            return BasicAuthProvider.FromJson(container.Credential);
        }
    }
}