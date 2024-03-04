using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service
{
    public class WeatherMonitor : WeatherSubject
    {
        public WeatherData WeatherData { get; set; }

        public void ChangeWeatherData(WeatherData weatherData)
        {
            WeatherData = weatherData;
            NotifyObservers(weatherData);
        }
    }
}
