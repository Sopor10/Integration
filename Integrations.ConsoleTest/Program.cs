using System;
using Integrations.HttpClient;
using Integrations.HttpClient.Credentials.Extensions;
using Microsoft.Extensions.DependencyInjection;

var provider = new ServiceCollection()
    .InstallHttpClient()
    .BuildServiceProvider();

var client = provider.GetService<IClient>();

var result = client
    .WithBaseUrl("https://www.googleapis.com/youtube/v3")
    .WithCredentials(x => x.File.Read("Youtube"))
    .WithEndpoint(x => x
        .AddFragments("channels"))
    .WithQueryParameters(x => x
        .AddParameter("id", "UCHfYy5WTpXYVXMeaXXSkbFQ")
        .AddParameter("part","contentDetails"))
    .Get();

var result2 = client
    .WithBaseUrl("http://192.168.0.2:8080")
    .WithCredentials(x => x.File.Read("Openfaas"))
    .WithEndpoint(x => x
        .AddFragments("system/functions"))
    .Get();

var httpResponseMessage = await result.Execute();
Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
