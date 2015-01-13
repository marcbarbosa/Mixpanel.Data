using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mixpanel.Data.Models
{
    public class SegmentationData
    {
        [JsonProperty(PropertyName = "series")]
        public List<DateTime> Series { get; set; }

        [JsonProperty(PropertyName = "values")]
        public Dictionary<string, Dictionary<string, int>> Values { get; set; }

        [JsonProperty(PropertyName = "legend_size")]
        public int LegendSize { get; set; }
    }
}
