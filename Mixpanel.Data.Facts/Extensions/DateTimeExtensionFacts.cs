using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mixpanel.Data.Extensions;
using Xunit;
using Xunit.Extensions;

namespace Mixpanel.Data.Facts.Extensions
{
    public class DateTimeExtensionFacts
    {
        public class ToUnixTimestamp
        {
            [Fact]
            public void ReturnsZeroGivenADateBefore1970_01_01()
            {
                // arrange
                // act
                var actual = new DateTime(1962, 9, 10).ToUnixTimestamp();

                // assert
                Assert.Equal(0, actual);
            }

            [Fact]
            public void ReturnsZeroGivenADateEqual1970_01_01()
            {
                // arrange
                // act
                var actual = new DateTime(1970, 1, 1).ToUnixTimestamp();

                // assert
                Assert.Equal(0, actual);
            }

            [Fact]
            public void ReturnsNineGivenADateEqual1970_01_01_00_00_9_987()
            {
                // arrange
                // act
                var actual = new DateTime(1970, 1, 1, 0, 0, 9, 987).ToUnixTimestamp();

                // assert
                Assert.Equal(9, actual);
            }

            [Fact]
            public void Returns1406134740GivenADateEqual2014_07_23_16_59()
            {
                // arrange
                // act
                var actual = new DateTime(2014, 7, 23, 16, 59, 0).ToUnixTimestamp();

                // assert
                Assert.Equal(1406134740, actual);
            }
        }
    }
}
