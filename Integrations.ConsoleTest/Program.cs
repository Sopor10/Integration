using System;
using Integrations.HttpClient;
using Integrations.HttpClient.Credentials.Extensions;

var client = new ClientFactory().Create();

var result = client
    .WithBaseUrl("https://www.googleapis.com/youtube/v3")
    .WithEndpoint(x => x
        .AddFragments("channels"))
    .WithQueryParameters(x => x
        .AddParameter("id", "UCHfYy5WTpXYVXMeaXXSkbFQ")
        .AddParameter("part","contentDetails"))
    .Get();

var result2 = client
    .WithBaseUrl("http://192.168.0.2:8080")
    .WithEndpoint(x => x
        .AddFragments("system/functions"))
    .Get();

//Console.WriteLine(await (await result.Execute()).Content.ReadAsStringAsync());
Console.WriteLine(await (await result2.Execute()).Content.ReadAsStringAsync());
