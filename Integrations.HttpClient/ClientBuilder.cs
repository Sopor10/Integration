namespace Integrations.HttpClient
{
    public record ClientBuilder
    {
        public string BaseUrl { get; init; }
        public string Endpoint { get; init; }
        public string QueryParameter { get; init; }


        public ClientBuilder WithBaseUrl(string baseUrl) => this with { BaseUrl = baseUrl };

        public ClientBuilder WithEndpoint(string endpoint) => this with { Endpoint = endpoint };

        public ClientBuilder WithQueryParameter(string queryParameter) => this with { QueryParameter = queryParameter };
    }
}