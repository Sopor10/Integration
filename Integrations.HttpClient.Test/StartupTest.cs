using Integrations.HttpClient.Credentials.FileCredentialProvider;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Integrations.HttpClient.Test
{
    [TestFixture]
    public class StartupTest
    {
        private ServiceProvider Provider()=> new ServiceCollection()
            .InstallHttpClient()
            .BuildServiceProvider();

        [Test]
        public void IClient_Can_Be_Resolved()
        {
            
            Assert.DoesNotThrow(() => Provider().GetService<IClient>());
        }
        
        [Test]
        public void ISecretReader_Can_Be_Resolved()
        {


            Assert.DoesNotThrow(()=>Provider().GetService<ISecretReader>());
        }
    }
}