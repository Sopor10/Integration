using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Authentication;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    public class HandlerList : IHandlerList
    {
        public ImmutableList<IHandler> Handlers { get; }

        public HandlerList(IEnumerable<IHandler> handlers)
        {
            Handlers = handlers.ToImmutableList();
        }
        public ICredentials Handle(CredentialContainer container)
        {
            foreach (var handler in Handlers)
            {
                var result = handler.Handle(container);
                if (result!= null)
                {
                    return result;
                }
            }
            throw new InvalidCredentialException($"Der Secrettyp {container.Type} wird nicht unterstützt.");
        }
    }
}