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
        public bool Enabled { get; set; }

        public SunBot(float temperatureThreshold, string message, bool enabled) 
        {
            TemperatureThreshold = temperatureThreshold;
            Message = message;
            Enabled = enabled;
        }

        public void Activate(WeatherData weatherData)
        {
            if (weatherData.Temperature > TemperatureThreshold && Enabled)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: {Message}");
            }
        }
    }
}
