using System;
using System.Linq;
using Newtonsoft.Json;

namespace Integrations.HttpClient.Credentials.FileCredentialProvider.Extensions
{
    internal abstract class GenericHandler : IHandler
    {
        public string[] Keys { get; }

        private GenericHandler()
        {
            Keys = Array.Empty<string>();
        }

        protected GenericHandler(string[] keys)
        {
            Keys = keys;
        }
        
        public ICredentials? Handle(string fileContent)
        {
            var container = JsonConvert.DeserializeObject<CredentialContainer>(fileContent);

            if (container == null ||!Keys.Contains(container?.Type))
            {
                return null;
            }
            return Handle(container!);
        }

        protected abstract ICredentials? Handle(CredentialContainer container);
    }
}