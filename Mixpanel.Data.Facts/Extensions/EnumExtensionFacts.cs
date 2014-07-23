using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xunit;

namespace Mixpanel.Data.Facts.Extensions
{
    public  class EnumExtensionFacts
    {
        public class ToDescriptionString
        {
            enum TestEnum
            {
                [Description("Teste")]
                FirstItem
            }

            [Fact]
            public void ReturnsTesteGivenTestEnumFirstItem()
            {
                // arrange
                // act
                var actual = TestEnum.FirstItem.ToDescriptionString();

                // assert
                Assert.Equal("Teste", actual);

            }
        }
        
    }
}
