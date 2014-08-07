using System;
using Xunit;

namespace Mixpanel.Data.Facts
{
    public class IntegrationFacts
    {
        [Fact(Skip="Integration test")]
        public void IntegrationTest()
        {
            var mixpanel = new MixpanelData();

            var response = mixpanel.Export(new DateTime(2014, 8, 1), new DateTime(2014, 8, 1)).Result;

            Assert.NotNull(response);
        }
    }
}
