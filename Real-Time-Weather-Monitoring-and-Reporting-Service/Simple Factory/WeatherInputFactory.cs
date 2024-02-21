using Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Simple_Factory
{
    public class WeatherInputFactory
    {
        public static IWeatherInputAdapter CreateAdapter(string weatherData)
        {         
            string dataFormat = weatherData.Trim().StartsWith("{") ? "JSON" : "XML";

            switch (dataFormat.ToUpperInvariant())
            {
                case "JSON":
                    return new JsonWeatherInputAdapter();
                case "XML":
                    return new XmlWeatherInputAdapter();
                default:
                    throw new InvalidOperationException($"No adapter found for data format: {dataFormat}");
            }
        }
    }
}
