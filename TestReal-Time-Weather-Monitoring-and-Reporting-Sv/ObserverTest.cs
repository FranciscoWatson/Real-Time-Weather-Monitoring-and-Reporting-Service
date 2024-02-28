using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Real_Time_Weather_Monitoring_and_Reporting_Service;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;

namespace TestReal_Time_Weather_Monitoring_and_Reporting_Sv
{
    public class ObserverTest
    {
        [Fact]
        public void NotifyWeatherBotsTest()
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization());
            
            var rainBot = fixture.Create<RainBot>();
            var sunBot = fixture.Create<SunBot>();
            var snowBot = fixture.Create<SnowBot>();
            


            var weatherMonitorMock = new Mock<WeatherMonitor>();

            var configuredBots = new List<IWeatherBot>
            {
                snowBot,
                rainBot,
                sunBot
            };

            foreach (var bot in configuredBots)
            {
                weatherMonitorMock.Object.AddObserver(bot);
            }

            var weatherData = fixture.Create<WeatherData>();

            // Act
            weatherMonitorMock.Object.ChangeWeatherData(weatherData);

            // Assert
            weatherMonitorMock.Verify(x => x.NotifyObservers(It.IsAny<WeatherData>()), Times.Once);
        }
    }
}