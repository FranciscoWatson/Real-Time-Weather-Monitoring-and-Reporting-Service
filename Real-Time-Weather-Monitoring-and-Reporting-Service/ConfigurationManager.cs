using Newtonsoft.Json;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service
{
    public class ConfigurationManager
    {
        public List<IWeatherBot> ReadConfiguration(string configurationPath)
        {
            string configurationJson = File.ReadAllText(configurationPath);
            var dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(configurationJson);

            IWeatherBot rainBot = new RainBot(
                Convert.ToSingle(dic["RainBot"]["humidityThreshold"]),
                dic["RainBot"]["message"].ToString(),
                Convert.ToBoolean(dic["RainBot"]["enabled"]));

            IWeatherBot sunBot = new SunBot(
                Convert.ToSingle(dic["SunBot"]["temperatureThreshold"]),
                dic["SunBot"]["message"].ToString(),
                Convert.ToBoolean(dic["SunBot"]["enabled"])
            );

            IWeatherBot snowBot = new SnowBot(
                Convert.ToSingle(dic["SnowBot"]["temperatureThreshold"]),
                dic["SnowBot"]["message"].ToString(),
                Convert.ToBoolean(dic["SnowBot"]["enabled"])
            );

            List<IWeatherBot> weatherBots = [rainBot, sunBot, snowBot];

            return weatherBots;
        }
    }
}
