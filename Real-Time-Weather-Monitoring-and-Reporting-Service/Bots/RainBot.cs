using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots.Bots_State;
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
        public float HumidityThreshold { get; set; }
        public string Message { get; set; }
        public IBotState currentBotState { get; set; }

        public RainBot(float humidityThreshold, string message, bool enabled) 
        {
            HumidityThreshold = humidityThreshold;
            Message = message;
            currentBotState = enabled ? new BotEnabledState() : new BotDisabledState();
        }

        public void Activate(WeatherData weatherData)
        {
            if (weatherData.Humidity > HumidityThreshold)
            {
                currentBotState.Activate(weatherData, "RainBot", Message);
            }
        }
    }
}
