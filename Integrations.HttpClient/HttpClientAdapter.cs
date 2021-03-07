using System.Net.Http;
using System.Threading.Tasks;

namespace Integrations.HttpClient
{
    public class HttpClientAdapter
    {
        public async Task<HttpResponseMessage> Execute(IClient client)
        {
            using var httpClient = new System.Net.Http.HttpClient();

            var httpRequestMessage = client.CreateRequest();
            
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}