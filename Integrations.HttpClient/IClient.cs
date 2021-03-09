using System;
using System.Net.Http;
using System.Threading.Tasks;
using Integrations.HttpClient.Credentials;
using Integrations.HttpClient.Url.Fragment;
using Integrations.HttpClient.Url.Header;
using Integrations.HttpClient.Url.QueryParameter;

namespace Integrations.HttpClient
{
    public interface IClient
    {
        public string? BaseUrl { get; }
        HttpMethod Method { get; }
        Uri RequestURI { get; }
        HeaderParameterList Header { get; }
        Task<System.Net.Http.HttpClient> ConfiguredHttpClient();
        public IClient WithBaseUrl(string baseUrl);
        public IClient WithCredentials(ICredentials credentials) => WithCredentials( x => credentials);
        public IClient WithCredentials(Func<CredentialProvider, ICredentials> func) => WithCredentials(x => Task.FromResult(func.Invoke(x)));
        public IClient WithCredentials(Func<CredentialProvider, Task<ICredentials>> func);
        public IClient WithEndpoint(FragmentList fragmentList);
        public IClient WithEndpoint(Func<FragmentListBuilder, FragmentListBuilder> func) =>
            WithEndpoint(func.Invoke(new FragmentListBuilder()).Build());

        public IClient WithQueryParameters(QueryParameterList queryParameterList);
        public IClient AddQueryParameter(QueryParameter parameter);

        public IClient WithQueryParameters(Func<QueryParameterListBuilder, QueryParameterListBuilder> func)
        {
            return WithQueryParameters(func.Invoke(new QueryParameterListBuilder()).Build());
        }
        public IClient Get();
        public IClient WithMethod(HttpMethod method);

        public Task<HttpResponseMessage> Execute();

        IClient AddHeader(string key, string value);
    }
}