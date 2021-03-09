using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Integrations.HttpClient.Credentials;
using Integrations.HttpClient.Credentials.FileCredentialProvider;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Integrations.HttpClient.Test.Credentials.FileCredentialsProvider
{
    [TestFixture]
    public class SecretReaderTest
    {
        private ServiceProvider Provider()=> new ServiceCollection()
            .InstallHttpClient(new Config(){SecrectDirectory = new DirectoryInfo("./Credentials/FileCredentialsProvider")})
            .BuildServiceProvider();

        private ISecretReader SecretReader() => Provider().GetService<ISecretReader>();

        [Test]
        public async Task Openfaas_Secret_Can_Be_Read_From_File()
        {
            ISecretReader sut = SecretReader();
            var result = await sut.Read("Openfaas");
            var basicAuth = result.Should().BeOfType<BasicAuth>().Subject;
            basicAuth.Password.Should().Be("admin");
            basicAuth.User.Should().Be("lars");

        }
        
        [Test]
        public async Task Youtube_Api_Key_Can_Be_Read_From_File()
        {
            ISecretReader sut = SecretReader();
            var result = await sut.Read("Youtube");
            var basicAuth = result.Should().BeOfType<QueryParameterAuth>().Subject;
            basicAuth.Key.Should().Be("key");
            basicAuth.Token.Should().Be("meinSecretKey");
        }
        
        [Test]
        public async Task N8N_Secret_Can_Be_Read_From_File()
        {
            ISecretReader sut = SecretReader();
            var result = await sut.Read("n8n-credential");
            var basicAuth = result.Should().BeOfType<QueryParameterAuth>().Subject;
            basicAuth.Key.Should().Be("key");
            basicAuth.Token.Should().Be("meinSecretKey");            
        }
    }
}