using System;
using Integrations.HttpClient;

namespace Openfaas
{
	public partial class swaggerClient
	{
		public swaggerClient(IClient client):this(client.BaseUrl, client.ConfiguredHttpClient())
		{
			
		}
		partial void PrepareRequest(System.Net.Http.HttpClient client,
			System.Net.Http.HttpRequestMessage request, string url)
		{
			Console.WriteLine("test");
		}
	}
}