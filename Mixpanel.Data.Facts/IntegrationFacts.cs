using System;
using Xunit;

namespace Mixpanel.Data.Facts
{
    public class IntegrationFacts
    {
        [Fact]
        public void IntegrationTest()
        {
            var mixpanel = new MixpanelData();

            //var response = mixpanel.Export(new DateTime(2014, 8, 11), new DateTime(2014, 8, 11)).Result;
            var response = mixpanel.ExportStream(new DateTime(2014, 8, 11), new DateTime(2014, 8, 11), where: "properties[\"distinct_id\"] == \"b4d8c07b-b083-48f8-8f01-c83c197396d9\"").Result;
            //var response = mixpanel.Export(new DateTime(2014, 8, 11), new DateTime(2014, 8, 11), where: "event=[\"View-Home\"]").Result;

            Assert.NotNull(response);
        }
    }
}
