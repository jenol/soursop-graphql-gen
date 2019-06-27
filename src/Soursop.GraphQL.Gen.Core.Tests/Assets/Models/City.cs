using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Models
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("areas")]
        public Area[] Areas { get; set; }
    }
}
