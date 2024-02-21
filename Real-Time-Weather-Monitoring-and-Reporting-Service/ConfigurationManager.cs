using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service
{
    public class ConfigurationManager
    {
        public Dictionary<string, dynamic> ReadConfiguration(string configurationPath)
        {
            string configurationJson = File.ReadAllText(configurationPath);
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(configurationJson);
        }
    }
}
