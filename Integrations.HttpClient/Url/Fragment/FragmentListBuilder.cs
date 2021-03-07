using System.Collections.Immutable;
using System.Linq;

namespace Integrations.HttpClient.Url.Fragment
{
    public record FragmentListBuilder
    {
        internal ImmutableList<Fragment> Fragments { get; init; } = ImmutableList<Fragment>.Empty;

        public FragmentListBuilder AddFragments(params Fragment[] fragments) => this with {Fragments = Fragments.AddRange(fragments)};

        public FragmentListBuilder AddFragments(params string[] urlPart) => 
            AddFragments(urlPart
                .SelectMany(x => x.Split("/").Where(x => x != "").Select(x => new Fragment(x)))
                .ToArray());
        
        public FragmentList Build()
        {
            return new() {Values = Fragments};
        }
    }
}