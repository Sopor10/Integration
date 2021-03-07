using System.Collections.Immutable;
using System.Linq;

namespace Integrations.HttpClient.Url.QueryParameter
{
    public record QueryParameterListBuilder
    {
        internal ImmutableList<QueryParameter> Values { get; init; } = ImmutableList<QueryParameter>.Empty;

        public QueryParameterListBuilder AddParameter(params QueryParameter[] parameters) => this with {Values = Values.AddRange(parameters)};

        public QueryParameterListBuilder AddParameter(params (string Key,object Value )[] urlPart) => 
            AddParameter(urlPart
                .Select(x =>  new QueryParameter(x.Key, x.Value))
                .ToArray());

        public QueryParameterListBuilder AddParameter(string key, object value) => AddParameter((key, value));


        public QueryParameterList Build()
        {
            return new(Values);
        }
    }
}