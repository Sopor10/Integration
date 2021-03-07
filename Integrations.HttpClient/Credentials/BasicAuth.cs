namespace Integrations.HttpClient.Credentials
{
    public record BasicAuth(string User, string Password) : ICredentials
    {
        public IClient Authorize(IClient client)
        {
            var encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(User + ":" + Password));
            client = client.AddHeader("Authorization", "Basic " + encoded);
            return client;
        }
    }
}