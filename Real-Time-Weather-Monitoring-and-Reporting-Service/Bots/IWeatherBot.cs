using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Bots
{
    public interface IWeatherBot : IWeatherObserver
    {
        void Activate(WeatherData weatherData);
    }
}
