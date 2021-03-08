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

        internal Uri RequestURI => new Uri(BaseUrl + FragmentList + QueryParameterList);

        internal string? BaseUrl { get; init; } 
        internal Func<CredentialProvider, Task<ICredentials>> Credentials { get; init; }
        internal HttpMethod Method { get; init; }

        internal FragmentList FragmentList { get; init; } = new FragmentListBuilder().Build();
        internal QueryParameterList QueryParameterList { get; init; } = new QueryParameterListBuilder().Build();
        internal HeaderParameterList Header { get; init; } = new();


        public IClient WithBaseUrl(string baseUrl) => this with { BaseUrl = baseUrl };
        public IClient WithCredentials(Func<CredentialProvider, Task<ICredentials>> func)
        {
            return this with {Credentials = func};
        }

        public IClient WithEndpoint(FragmentList fragmentList) => this with { FragmentList = fragmentList };

        public IClient WithQueryParameters(QueryParameterList queryParameterList) =>
            this with { QueryParameterList = queryParameterList };

        public IClient AddQueryParameter(QueryParameter parameter) =>
            WithQueryParameters(QueryParameterList.Add(parameter));

        public IClient Get() => WithMethod(HttpMethod.Get);

        public IClient WithMethod(HttpMethod method) => this with { Method =  method};

        public async Task<HttpResponseMessage> Execute()
        {
            var cred = await Credentials.Invoke(CredentialProvider);
            var authorizedClient = cred.Authorize(this);
            
            return await new HttpClientAdapter().Execute(authorizedClient);
        }

        public HttpRequestMessage CreateRequest()
        {
            HttpRequestMessage httpRequestMessage = new()
            {
                Method = Method,
                RequestUri = RequestURI,
            };
            httpRequestMessage.Headers.Add(Header);
            
            return httpRequestMessage;
        }

        public IClient AddHeader(string key, string value)
        {
            return this with{Header = Header.Add(key, value)};
        }
    }
}
