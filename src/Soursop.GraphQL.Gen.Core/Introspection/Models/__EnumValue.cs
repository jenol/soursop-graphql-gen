using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __EnumValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isDeprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("deprecationReason")]
        public string DeprecationReason { get; set; }
    }
}
