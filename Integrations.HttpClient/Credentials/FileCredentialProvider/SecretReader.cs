using System.IO;
using System.Threading.Tasks;
using Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions;
using Newtonsoft.Json;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    internal class SecretReader : ISecretReader
    {
        public Config Config { get; }
        public IHandlerList Handler { get; }

        public SecretReader(Config config, IHandlerList handler)
        {
            Config = config;
            Handler = handler;
        }

        public async Task<ICredentials> Read(string filename)
        {
            var fileContent = await File.ReadAllTextAsync(Config.FilePath(filename));

            var result = Handler.Handle(fileContent);
            return result;
        }
    }
}