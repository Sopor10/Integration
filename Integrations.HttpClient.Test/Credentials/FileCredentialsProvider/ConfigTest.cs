using FluentAssertions;
using Integrations.HttpClient.Credentials.FileCredentialProvider;
using NUnit.Framework;

namespace Integrations.HttpClient.Test.Credentials.FileCredentialsProvider
{
    [TestFixture]
    public class ConfigTest
    {
        [Test]
        public void DefaultConfig_Should_HaveValidFilePath()
        {
            var sut = new Config();
            Assert.DoesNotThrow(()=> sut.FilePath("test"));
            sut.FileExtension.Should().Be(".json");
        }
    }
}