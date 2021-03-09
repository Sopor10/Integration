using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Integrations.HttpClient;
using Openfaas;

namespace Integrations.ExternalClients
{
	public class Class1
	{
		public async Task Test()
		{
			IClient client = null;
			var result = await client
				.WithBaseUrl("http://localhost:5000")
				.Openfaas( x =>  x
				.InfoAsync());
		}
	}

	public static class IClientExtension
	{
		public static async Task<T> Openfaas<T>(this IClient client, Func<swaggerClient, T> func)
		{
			return func.Invoke(new swaggerClient(client.BaseUrl, await client.ConfiguredHttpClient()));
		}
		public static async Task<T> Openfaas<T>(this IClient client, Func<swaggerClient, Task<T>> func)
		{
			return await func.Invoke(new swaggerClient(client.BaseUrl, await client.ConfiguredHttpClient()));
		}
	}
}
