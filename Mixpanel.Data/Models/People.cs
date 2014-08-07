using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mixpanel.Data.Models
{
    public class People
    {
        [JsonProperty(PropertyName = "$distinct_id")]
        public string DistinctId { get; set; }

        [JsonProperty(PropertyName = "$properties")]
        public Dictionary<string, object> Properties { get; set; }
    }
}
