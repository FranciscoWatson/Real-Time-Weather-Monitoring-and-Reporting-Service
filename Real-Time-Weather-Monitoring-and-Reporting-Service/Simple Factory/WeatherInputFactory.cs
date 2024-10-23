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
        public static IWeatherInputStrategy CreateStrategy(string weatherData)
        {
            string dataFormat;

            if (weatherData.Trim().StartsWith("{"))
            {
                dataFormat = "JSON";
            }
            else if (weatherData.Trim().StartsWith("<"))
            {
                dataFormat = "XML";
            }
            else
            {
                throw new InvalidOperationException("No adapter found for data format.");
            }

            switch (dataFormat.ToUpperInvariant())
            {
                case "JSON":
                    return new JsonWeatherInputStrategy();
                case "XML":
                    return new XmlWeatherInputStrategy();
                default:
                    throw new InvalidOperationException("Unexpected data format.");
            }
        }
    }
}
