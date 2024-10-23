using Newtonsoft.Json;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots.Bots_State;
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
                 dic["RainBot"]["enabled"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase)
                            ? (IBotState)new BotEnabledState()
                            : (IBotState)new BotDisabledState()
            );

            IWeatherBot sunBot = new SunBot(
                Convert.ToSingle(dic["SunBot"]["temperatureThreshold"]),
                dic["SunBot"]["message"].ToString(),
                dic["SunBot"]["enabled"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase)
                            ? (IBotState)new BotEnabledState()
                            : (IBotState)new BotDisabledState()
            );

            IWeatherBot snowBot = new SnowBot(
                Convert.ToSingle(dic["SnowBot"]["temperatureThreshold"]),
                dic["SnowBot"]["message"].ToString(),
                 dic["SnowBot"]["enabled"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase)
                            ? (IBotState)new BotEnabledState()
                            : (IBotState)new BotDisabledState()
            );

            List<IWeatherBot> weatherBots = [rainBot, sunBot, snowBot];

            return weatherBots;
        }
    }
}
