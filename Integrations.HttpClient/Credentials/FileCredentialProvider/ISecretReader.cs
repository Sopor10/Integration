using System.Threading.Tasks;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider
{
    public interface ISecretReader
    {
        public Task<ICredentials> Read(string filename);
        
    }
}