using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __InputValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("args")]
        public __InputValue[] Args { get; set; }

        [JsonProperty("isDeprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("deprecationReason")]
        public string DeprecationReason { get; set; }
    }
}
