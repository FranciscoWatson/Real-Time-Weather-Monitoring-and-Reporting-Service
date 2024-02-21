using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter
{
    public class JsonWeatherInputStrategy : IWeatherInputStrategy
    {
        public WeatherData ParseWeatherData(string weatherInput)
        {
            return JsonConvert.DeserializeObject<WeatherData>(weatherInput);
        }
    }
}
