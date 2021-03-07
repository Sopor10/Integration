using NUnit.Framework;

namespace Integrations.HttpClient.Test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Build_Url_To_Example_Api_Should_Work()
        {
            var sut = new Client();
            var result = sut
                .WithBaseUrl("https://jsonplaceholder.typicode.com")
                .WithCredentials(x => x.None)
                .WithEndpoint(x => x
                    .AddFragments("comments"))
                .WithQueryParameters(x => x
                    .AddParameter("postId", 1))
                .Get();
            var url = ((Client) result).RequestURI;
            Assert.That(url.AbsoluteUri,Is.EqualTo("https://jsonplaceholder.typicode.com/comments?postId=1"));
        }
    }
}