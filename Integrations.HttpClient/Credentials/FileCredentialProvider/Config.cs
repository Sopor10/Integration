using System;
using System.IO;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public record Config
    {
        internal DirectoryInfo SecrectDirectory { get; init; } =
            new DirectoryInfo($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Credentials");
        internal string FileExtension { get; init; } = ".json";

        public string FilePath(string filename)
        {
            return SecrectDirectory.FullName + "/" + filename + FileExtension;
        }
    
        public static Config Openfaas()
        {
            return new Config()
            {
                FileExtension = "",
                SecrectDirectory = new DirectoryInfo("/var/openfaas/secrets")

            };
        }
    }    
}
