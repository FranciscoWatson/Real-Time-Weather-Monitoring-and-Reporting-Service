using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter
{
    public interface IWeatherInputStrategy
    {
        WeatherData ParseWeatherData(string weatherInput);
    }
}
