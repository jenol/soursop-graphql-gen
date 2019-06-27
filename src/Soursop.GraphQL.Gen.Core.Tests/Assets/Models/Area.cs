using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Models
{
    public class Area
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
