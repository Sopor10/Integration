namespace Integrations.HttpClient.Predifined
{
    public static class YoutubeDefaults
    {
        public static IClient Youtube(this IClient client) =>
            client
                .WithBaseUrl("https://www.googleapis.com/youtube/v3")
                .WithCredentials(x => x.File.Read("Youtube"));
    }
}