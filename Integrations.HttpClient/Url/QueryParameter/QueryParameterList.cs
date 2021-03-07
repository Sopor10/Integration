using System.Collections.Immutable;
using System.Text;

namespace Integrations.HttpClient.Url.QueryParameter
{
    public record QueryParameterList(ImmutableList<QueryParameter>Values)
    {
        public override string ToString()
        {
            if (Values.Count==0)
            {
                return "";
            }
            var builder = new StringBuilder();
            builder.Append('?');
            foreach (var value in Values)
            {
                builder.Append( value + "&"); 
            }

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public QueryParameterList Add(params QueryParameter[] parameter)
        {
            return this with {Values = Values.AddRange(parameter)};
        }
        public QueryParameterList Add(QueryParameterList parameter)
        {
            return this with { Values = Values.AddRange(parameter.Values)};
        }
    }
}