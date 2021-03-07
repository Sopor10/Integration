using System.Collections.Immutable;

namespace Integrations.HttpClient.Url.Header
{
    public record HeaderParameter(string key, object Value);

    public record HeaderParameterList(ImmutableList<HeaderParameter> Values)
    {
        public HeaderParameterList():this(ImmutableList<HeaderParameter>.Empty)
        {
            
        }
        public HeaderParameterList Add(HeaderParameterList other)
        {
            return new(Values.AddRange(other.Values));
        }
        
        public HeaderParameterList Add(params HeaderParameter[] other)
        {
            return new(Values.AddRange(other));
        }
    }

    public static class HeaderParameterListBuilder
    {
        public static HeaderParameterList Add(this HeaderParameterList list, string key, object value)
        {
            return list.Add(new HeaderParameter(key, value));
        }
        
    }
}