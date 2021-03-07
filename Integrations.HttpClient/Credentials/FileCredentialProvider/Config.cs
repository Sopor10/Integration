using System.IO;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public record Config
    {
        internal DirectoryInfo SecrectDirectory { get; init; }
    }
}