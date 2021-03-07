using System;
using System.IO;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public record Config
    {
        internal DirectoryInfo SecrectDirectory { get; init; } =
            new($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Credentials");
        internal string FileExtension { get; init; } = ".json";

        public string FilePath(string filename)
        {
            return SecrectDirectory.FullName + "/" + filename + FileExtension;
        }
    

    }    
}
