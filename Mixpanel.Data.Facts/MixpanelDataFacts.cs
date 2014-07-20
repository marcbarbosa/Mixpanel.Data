using Moq;
using System;
using System.Collections.Specialized;
using System.Configuration.Abstractions;
using Xunit;

namespace Mixpanel.Data.Facts
{
    public class MixpanelDataFacts
    {
        public class Constructor
        {
            private readonly Mock<IConfigurationManager> mockConfigurationManager = new Mock<IConfigurationManager>();

            [Fact]
            public void ReturnsArgmentNullExceptionGivenEmptyConfig()
            {
                // arrange
                mockConfigurationManager.Setup(c => c.AppSettings).Returns(new AppSettingsExtended(new NameValueCollection()));

                // act
                // assert
                Assert.Throws<ArgumentNullException>(() => new MixpanelData(mockConfigurationManager.Object));
            }

            [Fact]
            public void ReturnsNoExceptionIfAllKeysAreConfigured()
            {
                // arrange
                var appSettings = new AppSettingsExtended(new NameValueCollection
                {
                    { Constants.SettingKeys.ApiKey, "ApiKey" },
                    { Constants.SettingKeys.ApiSecret, "ApiSecret" },
                    { Constants.SettingKeys.Token, "Token" },
                });
                mockConfigurationManager.Setup(c => c.AppSettings).Returns(appSettings);

                // act
                // assert
                Assert.DoesNotThrow(() => new MixpanelData(mockConfigurationManager.Object));
            }

            [Fact]
            public void ShouldSetAllProperties()
            {
                // arrange
                var expectedApiKey = "expectedApiKey";
                var expectedApiSecret = "expectedApiSecret";
                var expectedToken = "expectedToken";

                var appSettings = new AppSettingsExtended(new NameValueCollection
                {
                    { Constants.SettingKeys.ApiKey, expectedApiKey },
                    { Constants.SettingKeys.ApiSecret, expectedApiSecret },
                    { Constants.SettingKeys.Token, expectedToken },
                });

                mockConfigurationManager.Setup(c => c.AppSettings).Returns(appSettings);

                // act
                var sut = new MixpanelData(mockConfigurationManager.Object);
                
                // assert
                Assert.Equal(expectedApiKey, sut.ApiKey);
                Assert.Equal(expectedApiSecret, sut.ApiSecret);
                Assert.Equal(expectedToken, sut.Token);
            }
        }

        public class People
        {
            
        }
    }
}
