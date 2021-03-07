using System.Net.Http;

namespace Integrations.HttpClient.Credentials
{
    public interface ICredentials
    {
        IClient Authorize(IClient client);
    }
}