using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mixpanel.Data.Models
{
    public class Event
    {
        [JsonProperty(PropertyName = "event")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, string> Properties { get; set; }
    }
}
