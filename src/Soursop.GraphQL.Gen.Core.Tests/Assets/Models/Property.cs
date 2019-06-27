using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Soursop.GraphQL.Gen.Core.Tests.Assets.Models
{
    public class Property
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("formerName")]
        public string FormerName { get; set; }
        
        [JsonProperty("chainId")]
        public int ChainId { get; set; }

        [JsonProperty("starRating")]
        public float StarRating { get; set; }

        [JsonProperty("City")]
        public City City { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }
}
