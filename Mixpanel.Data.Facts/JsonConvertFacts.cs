using Mixpanel.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace Mixpanel.Data.Facts
{
    public class JsonConvertFacts
    {
        [Fact]
        public void CanDeserializeSampleJsonString()
        {
            // arrange
            var json = "{\"event\":\"View-Discipline\",\"properties\":{\"time\":1406904966,\"distinct_id\":\"1376179\",\"$browser\":\"Chrome\",\"$initial_referrer\":\"http://descomplica.com.br/\",\"$initial_referring_domain\":\"descomplica.com.br\",\"$os\":\"Windows\",\"$referrer\":\"http://descomplica.com.br/\",\"$referring_domain\":\"descomplica.com.br\",\"$screen_height\":768,\"$screen_width\":1366,\"$search_engine\":\"google\",\"__mpso\":{},\"discipline\":\"biologia\",\"gt_Discipline\":\"biologia\",\"gt_UserType\":\"Assinante\",\"mp_country_code\":\"BR\",\"mp_keyword\":\"cache:http://descomplica.com.br/redacao/resumo-para-o-enem-coesao-textual-redacao/coerencia-externa-ou-conhecimento-de-mundo\",\"mp_lib\":\"web\"}}";

            var expected = new Event
            {
                Name = "View-Discipline",
                Properties = new Dictionary<string, object> 
                {
                    { "time", (long)1406904966 },
                    { "distinct_id", "1376179" },
                    { "__mpso", new JObject() }
                }
            };

            // act
            var actual = JsonConvert.DeserializeObject<Event>(json);

            // assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Properties["time"], actual.Properties["time"]);
            Assert.Equal(expected.Properties["distinct_id"], actual.Properties["distinct_id"]);
            Assert.Equal(expected.Properties["__mpso"], actual.Properties["__mpso"]);
        }
    }
}
