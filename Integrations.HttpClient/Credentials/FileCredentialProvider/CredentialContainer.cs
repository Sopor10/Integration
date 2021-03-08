using Newtonsoft.Json.Linq;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public record CredentialContainer
    {
        private CredentialContainer()
        {
            Type = "";
            Credential = new JObject();
        }
        public CredentialContainer(string type, JObject credential)
        {
            Type = type;
            Credential = credential;
        }
        public string Type { get; } 
        public JObject Credential { get; }
    }
}