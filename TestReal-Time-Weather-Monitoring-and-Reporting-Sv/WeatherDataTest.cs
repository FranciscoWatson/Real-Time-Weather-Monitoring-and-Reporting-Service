using AutoFixture;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
namespace TestReal_Time_Weather_Monitoring_and_Reporting_Sv
{
    public class WeatherDataTest
    {
        [Fact]
        public void WeatherData_ToString_ShouldReturnExpectedString()
        {
            // Arrange
            var fixture = new Fixture();
            var weatherData = fixture.Create<WeatherData>();
            var expectedString = $"Location: {weatherData.Location}, Temperature: {weatherData.Temperature}, Humidity: {weatherData.Humidity}";

            // Act
            var result = weatherData.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }
    }
}
