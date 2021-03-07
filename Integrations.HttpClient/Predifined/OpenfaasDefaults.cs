namespace Integrations.HttpClient.Predifined
{
    public static class OpenfaasDefaults
    {
        public static IClient Openfaas(this IClient client, string gateway = "http://192.168.0.2:8080") =>
            client
                .WithBaseUrl(gateway)
                .WithCredentials(x => x.File.Read("Openfaas"));
    }
}