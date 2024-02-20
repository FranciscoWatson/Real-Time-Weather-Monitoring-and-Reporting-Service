using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter
{
    public interface IWeatherInputAdapter
    {
        WeatherData ParseWeatherData(string weatherInput);
    }
}
