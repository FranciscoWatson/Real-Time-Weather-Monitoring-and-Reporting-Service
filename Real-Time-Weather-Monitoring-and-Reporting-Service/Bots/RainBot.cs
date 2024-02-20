using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Bots
{
    public class RainBot : IWeatherBot
    {
        public float HumidityThreshold { get; }
        public string Message { get; set; }

        public RainBot(float humidityThreshold, string message) 
        {
            HumidityThreshold = humidityThreshold;
            Message = message;
        }

        public void Activate(WeatherData weatherData)
        {
            if (weatherData.Humidity > HumidityThreshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: {Message}");
            }
        }
    }
}
