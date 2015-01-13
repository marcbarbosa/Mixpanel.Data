using Mixpanel.Data.Models;
using Newtonsoft.Json;

namespace Mixpanel.Data.ResponseModels
{
    public class SegmentationResponse
    {
        [JsonProperty(PropertyName = "data")]
        public SegmentationData Data { get; set; }
    }
}
