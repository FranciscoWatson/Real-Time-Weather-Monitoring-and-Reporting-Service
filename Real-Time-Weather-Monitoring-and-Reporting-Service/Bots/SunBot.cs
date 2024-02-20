using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Bots
{
    public class SunBot : IWeatherBot
    {
        public float TemperatureThreshold {  get; set; }
        public string Message { get; set; }

        public SunBot(float temperatureThreshold, string message) 
        {
            TemperatureThreshold = temperatureThreshold;
            Message = message;
        }

        public void Activate(WeatherData weatherData)
        {
            if (weatherData.Temperature > TemperatureThreshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: {Message}");
            }
        }
    }
}
