using Microsoft.VisualStudio.TestPlatform.Utilities;
using Real_Time_Weather_Monitoring_and_Reporting_Service;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;

namespace TestReal_Time_Weather_Monitoring_and_Reporting_Sv
{
    public class ObserverTest
    {
        [Fact]
        public void AddNewWeatherDataToWeatherMonitorNotifyObservers()
        {
            WeatherMonitor weatherMonitor = new WeatherMonitor();
            IWeatherBot rainBot = new RainBot(70f, "Raining!", true);
            IWeatherBot sunBot = new SunBot(30f, "Sunny!", true);
            weatherMonitor.AddObserver(rainBot);
            weatherMonitor.AddObserver(sunBot);


            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            weatherMonitor.ChangeWeatherData(new WeatherData("Argentina", 75, 75));


            Assert.Contains("Raining!", consoleOutput.ToString());
            Assert.Contains("Sunny!", consoleOutput.ToString());

        }
    }
}