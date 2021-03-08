using System.Collections.Immutable;
using System.Text;

namespace Integrations.HttpClient.Url.Fragment
{
    public record FragmentList
    {
        internal ImmutableList<Fragment> Values { get; init; } = ImmutableList<Fragment>.Empty;

        public override string ToString()
        {
            if (Values.Count == 0)
            {
                return "";
            }

            var builder = new StringBuilder();
            foreach (var value in Values)
            {
                builder.Append("/" + value.Value); 
            }

            return builder.ToString();
        }
    }
}