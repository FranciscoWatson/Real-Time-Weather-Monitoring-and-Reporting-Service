using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
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
        [Fact]
        public void BotWithEnabledStateShouldPrintOnConsole()
        {
            IWeatherBot rainBot = new RainBot(70f, "Raining!", true);
            WeatherData newWeatherData = new WeatherData("Argentina", 75, 75);

            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);
            rainBot.Activate(newWeatherData);

            Assert.Contains("Raining!", consoleOutput.ToString());
        }


        [Fact]
        public void BotWithDisabledStateShouldNotPrintOnConsole()
        {
            IWeatherBot rainBot = new RainBot(70f, "Raining!", false);
            WeatherData newWeatherData = new WeatherData("Argentina", 75, 75);

            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);
            rainBot.Activate(newWeatherData);

            Assert.DoesNotContain("Raining!", consoleOutput.ToString());
        }
    }
}
