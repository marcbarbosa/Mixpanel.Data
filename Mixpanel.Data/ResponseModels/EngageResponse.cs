using Mixpanel.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mixpanel.Data.ResponseModels
{
    public class EngageResponse
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<People> Results { get; set; }

        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
