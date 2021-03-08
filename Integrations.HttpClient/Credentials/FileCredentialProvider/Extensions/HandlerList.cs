using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Authentication;
using Newtonsoft.Json;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public class HandlerList : IHandlerList
    {
        public ImmutableList<IHandler> Handlers { get; }

        public HandlerList(IEnumerable<IHandler> handlers)
        {
            Handlers = handlers.ToImmutableList();
        }
        public ICredentials Handle(string container)
        {
            foreach (var handler in Handlers)
            {
                var result = handler.Handle(container);
                if (result!= null)
                {
                    return result;
                }
            }
            var credentialContainer = JsonConvert.DeserializeObject<CredentialContainer>(container);

            throw new InvalidCredentialException($"Der Secrettyp {credentialContainer?.Type??"nichts"} wird nicht unterstützt.");
        }
    }
}