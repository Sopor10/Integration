using System;
using Integrations.ExternalClients;
using Integrations.HttpClient;
using Integrations.HttpClient.Predifined;
using Microsoft.Extensions.DependencyInjection;

var provider = new ServiceCollection()
    .InstallHttpClient()
    .BuildServiceProvider();

var client = provider.GetService<IClient>();

var result = client
    .Youtube()
    .WithEndpoint(x => x
        .AddFragments("channels"))
    .WithQueryParameters(x => x
        .AddParameter("id", "UCHfYy5WTpXYVXMeaXXSkbFQ")
        .AddParameter("part","contentDetails"))
    .Get();

var result2 = client
    .Openfaas()
    .WithEndpoint(x => x
        .AddFragments("system/functions"))
    .Get();
var result3 = await client
	.Openfaas()
	.Openfaas(x => x
		.InfoAsync());
var httpResponseMessage = await result2.Execute();
Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
