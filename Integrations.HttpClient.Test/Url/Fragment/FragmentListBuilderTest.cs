using FluentAssertions;
using Integrations.HttpClient.Url.Fragment;
using NUnit.Framework;

namespace Integrations.HttpClient.Test
{
    [TestFixture]
    public class FragmentListBuilderTest
    {
        [Test]
        public void Adding_Fragments_As_SingleString_Adds_Fragments()
        {
            var sut = new FragmentListBuilder();
            var result = sut
                .AddFragments("/system/functions/")
                .Build();

            result.Values.Count.Should().Be(2);
        }
        
        [Test]
        public void Adding_Fragments_As_Array_Adds_Fragments()
        {
            var sut = new FragmentListBuilder();
            var result = sut
                .AddFragments("system/functions")
                .Build();

            result.Values.Count.Should().Be(2);
        }
    }
}