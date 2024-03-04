using Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Simple_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReal_Time_Weather_Monitoring_and_Reporting_Sv
{
   
    public class WeatherInputFactoryTest
    {
        [Theory]
        [InlineData("{...}", typeof(JsonWeatherInputStrategy))]
        [InlineData("<...>", typeof(XmlWeatherInputStrategy))]
        public void CreateStrategyShouldReturnCorrectStrategyTest(string rawweatherData, Type expectedStrategyType)
        {
            // Arrange & Act 
            var strategy = WeatherInputFactory.CreateStrategy(rawweatherData);

            // Assert
            Assert.IsType(expectedStrategyType, strategy);
        }

        [Fact]
        public void CreateStrategyWithInvalidDataFormatShouldThrowInvalidOperationExceptionTest()
        {
            // Arrange
            var invalidDataFormat = "InvalidFormat";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => WeatherInputFactory.CreateStrategy(invalidDataFormat));

        }
    }
}
