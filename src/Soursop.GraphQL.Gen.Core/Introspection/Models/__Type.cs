using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __Type
    {
        [JsonProperty("kind")]
        public __TypeKind Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fields")]
        public __Field[] Fields { get; set; }

        [JsonProperty("inputFields")]
        public __InputValue[] InputFields { get; set; }

        [JsonProperty("ofType")]
        public __Type OfType { get; set; }
    }
}
