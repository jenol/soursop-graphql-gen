using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Introspection.Models
{
    public class __Directive
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("locations")]
        public __DirectiveLocation[] Locations { get; set; }

        [JsonProperty("args")]
        public __InputValue[] Args { get; set; }
    }
}
