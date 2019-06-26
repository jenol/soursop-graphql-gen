using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __Schema
    {
        [JsonProperty("types")]
        public __Type[] Types { get; set; }

        [JsonProperty("queryType")]
        public __Type QueryType { get; set; }

        [JsonProperty("mutationType")]
        public __Type MutationType { get; set; }

        [JsonProperty("subscriptionType")]
        public __Type SubscriptionType { get; set; }

        [JsonProperty("directives")]
        public __Directive[] Directives { get; set; }
    }
}
