using System;
using System.Net.Http;
using System.Threading.Tasks;
using Integrations.HttpClient.Credentials;
using Integrations.HttpClient.Url.Fragment;
using Integrations.HttpClient.Url.Header;
using Integrations.HttpClient.Url.QueryParameter;

namespace Integrations.HttpClient
{
    internal record Client : IClient
    {
        public Client(CredentialProvider credentialProvider)
        {
            CredentialProvider = credentialProvider;
            Method = HttpMethod.Get;
            Credentials = x => Task.FromResult(x.None);
        }

        public CredentialProvider CredentialProvider { get; } 

        public Uri RequestURI => new Uri(BaseUrl + FragmentList + QueryParameterList);

        public string? BaseUrl { get; init; }

        internal Func<CredentialProvider, Task<ICredentials>> Credentials { get; init; }

        public HttpMethod Method { get; init; }
        
        internal FragmentList FragmentList { get; init; } = new FragmentListBuilder().Build();
        
        internal QueryParameterList QueryParameterList { get; init; } = new QueryParameterListBuilder().Build();

        public HeaderParameterList Header { get; init; } = new();

        public IClient WithBaseUrl(string baseUrl) => this with { BaseUrl = baseUrl };
        
        public IClient WithCredentials(Func<CredentialProvider, Task<ICredentials>> func) => this with {Credentials = func};

        public IClient WithEndpoint(FragmentList fragmentList) => this with { FragmentList = fragmentList };

        public IClient WithQueryParameters(QueryParameterList queryParameterList) => this with { QueryParameterList = queryParameterList };

        public IClient AddQueryParameter(QueryParameter parameter) => WithQueryParameters(QueryParameterList.Add(parameter));

        public IClient Get() => WithMethod(HttpMethod.Get);

        public IClient WithMethod(HttpMethod method) => this with { Method =  method};
        
        public Task<HttpResponseMessage> Execute()
        {
	        return new ExecuteRequest().Execute(this);
        }

        public Task<System.Net.Http.HttpClient> ConfiguredHttpClient()
        {
	        return new ExecuteRequest().ConfiguredHttpClient(this);
        }

        public IClient AddHeader(string key, string value)
        {
            return this with { Header = Header.Add(key, value) };
        }
    }

    internal class ExecuteRequest
    {
	    public async Task<HttpResponseMessage> Execute(Client client)
	    {
		    var cred = await client.Credentials.Invoke(client.CredentialProvider);
		    var authorizedClient = cred.Authorize(client);

		    using var httpClient = new System.Net.Http.HttpClient();

		    var httpRequestMessage = CreateRequest(authorizedClient);

		    return await httpClient.SendAsync(httpRequestMessage);
        }


	    public async Task<System.Net.Http.HttpClient> ConfiguredHttpClient(Client client)
	    {
		    var cred = await client.Credentials.Invoke(client.CredentialProvider);
		    var authorizedClient = cred.Authorize(client);
		    var httpClient = new System.Net.Http.HttpClient();
		    httpClient.DefaultRequestHeaders.Add(client.Header);

		    return httpClient;
	    }

	    private HttpRequestMessage CreateRequest(IClient client)
	    {
		    HttpRequestMessage httpRequestMessage = new()
		    {
			    Method = client.Method,
			    RequestUri = client.RequestURI,
		    };

		    httpRequestMessage.Headers.Add(client.Header);

		    return httpRequestMessage;
	    }
    }
}
