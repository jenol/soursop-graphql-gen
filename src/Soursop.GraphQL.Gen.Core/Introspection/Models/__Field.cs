using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __Field
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("args")]
        public __InputValue[] Args { get; set; }

        [JsonProperty("type")]
        public __Type Type { get; set; }

        [JsonProperty("isDeprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("deprecationReason")]
        public string DeprecationReason { get; set; }
    }
}
