using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Bots
{
    public class SnowBot : IWeatherBot
    {
        public float TemperatureThreshold { get; set; }
        public string Message { get; set; }
        public bool Enabled { get; set; }

        public SnowBot(float temperatureThreshold, string message, bool enabled) 
        { 
            TemperatureThreshold = temperatureThreshold;
            Message = message;
            Enabled = enabled;
        }

        public void Activate(WeatherData weatherData)
        {
            if (weatherData.Temperature < TemperatureThreshold && Enabled)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: {Message}");
            }
        }
    }
}
