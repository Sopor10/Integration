using System.Net.Http;

namespace Integrations.HttpClient.Credentials
{
    internal class NoCredentials : ICredentials
    {
        public IClient Authorize(IClient client) => client;
    }
}