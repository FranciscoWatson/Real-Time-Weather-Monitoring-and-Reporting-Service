using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Models
{
    public class WeatherData
    {
        public string Location { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }

        public WeatherData(string location, float temperature, float humidity) 
        {
            Location = location;
            Temperature = temperature;
            Humidity = humidity;
        }
        public override string ToString()
        {
            return $"Location: {Location}, Temperature: {Temperature}, Humidity: {Humidity}";
        }

    }

    
}
