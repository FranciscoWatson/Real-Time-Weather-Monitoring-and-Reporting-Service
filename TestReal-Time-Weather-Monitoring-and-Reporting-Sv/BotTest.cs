using AutoFixture;
using Moq;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots.Bots_State;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReal_Time_Weather_Monitoring_and_Reporting_Sv
{
    public class BotTest
    {
        Fixture fixture = new Fixture();
        Mock<IBotState> botStateMock = new Mock<IBotState>();
        [Fact]
        public void RainBotCallsActivateOnItsStateWhenHumidityIsHigherTest()
        {
            // Arrange
            var rainBot = new RainBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Humidity, rainBot.HumidityThreshold + 1)
                                    .Create();


            // Act
            rainBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once
            );
        }

        [Fact]
        public void RainBotDoesNotCallsActivateOnItsStateWhenHumidityIsLowerTest()
        {
            // Arrange
            var rainBot = new RainBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Humidity, rainBot.HumidityThreshold - 1)
                                    .Create();


            // Act
            rainBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never
            );
        }


        [Fact]
        public void SnowBotCallsActivateOnItsStateWhenTemperatureIsLowerTest()
        {
            // Arrange
            var snowBot = new SnowBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Temperature, snowBot.TemperatureThreshold - 1)
                                    .Create();


            // Act
            snowBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once
            );
        }

        [Fact]
        public void SnowBotDoesNotCallActivateOnItsStateWhenTemperatureIsHigherTest()
        {
            // Arrange
            var snowBot = new SnowBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Temperature, snowBot.TemperatureThreshold + 1)
                                    .Create();


            // Act
            snowBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never
            );
        }


        [Fact]
        public void SunBotCallsActivateOnItsStateWhenTemperatureIsHigherTest()
        {
            // Arrange
            var sunBot = new SunBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Temperature, sunBot.TemperatureThreshold + 1)
                                    .Create();


            // Act
            sunBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once
            );
        }

        [Fact]
        public void SunBotDoesNotCallActivateOnItsStateWhenTemperatureIsLowerTest()
        {
            // Arrange
            var sunBot = new SunBot(
                fixture.Create<float>(),
                fixture.Create<string>(),
                botStateMock.Object
            );

            var weatherData = fixture.Build<WeatherData>()
                                    .With(wb => wb.Temperature, sunBot.TemperatureThreshold - 1)
                                    .Create();


            // Act
            sunBot.Activate(weatherData);

            // Assert
            botStateMock.Verify(
                x => x.Activate(It.IsAny<WeatherData>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never
            );
        }

    }
}
