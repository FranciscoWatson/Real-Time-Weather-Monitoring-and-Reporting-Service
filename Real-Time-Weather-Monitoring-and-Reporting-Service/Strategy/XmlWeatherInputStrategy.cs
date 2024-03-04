using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter
{
    public class XmlWeatherInputStrategy : IWeatherInputStrategy
    {
        public WeatherData ParseWeatherData(string weatherInput)
        {
            XElement weatherXml = XElement.Parse(weatherInput);
            string location = weatherXml.Element("Location").Value;
            float temperature = Convert.ToSingle(weatherXml.Element("Temperature").Value);
            float humidity = Convert.ToSingle(weatherXml.Element("Humidity").Value);

            return new WeatherData(location, temperature, humidity);
        }
    }
}
