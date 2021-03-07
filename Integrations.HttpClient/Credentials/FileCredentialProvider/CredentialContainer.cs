using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public record CredentialContainer
    {
        public string Type { get; init; } 
        public JObject Credential { get; init; }
    }
}