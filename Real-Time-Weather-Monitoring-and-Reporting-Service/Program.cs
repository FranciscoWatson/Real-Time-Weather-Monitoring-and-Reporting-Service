using Real_Time_Weather_Monitoring_and_Reporting_Service.Adapter;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Bots;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using Real_Time_Weather_Monitoring_and_Reporting_Service.Simple_Factory;
using System.ComponentModel.Design;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service
{
    public class Program
    {
        static void Main()
        {

            WeatherMonitor weatherMonitor = new WeatherMonitor();

            LoadConfiguration(weatherMonitor);

            LoadUserInterface(weatherMonitor);

        }

        private static void LoadConfiguration(WeatherMonitor weatherMonitor)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();

            Console.WriteLine("--- Real Time Weather Monitoring and Reporting Service ---");
            Console.WriteLine("Enter your configuration path to start: ");

            string path = Console.ReadLine();

            var botsConfiguration = configurationManager.ReadConfiguration(path);

            foreach (var bot in botsConfiguration)
            {
                weatherMonitor.AddObserver(bot);
            }
        }

        private static void LoadUserInterface(WeatherMonitor weatherMonitor)
        {
            bool userInterface = true;

            while (userInterface)
            {
                Console.WriteLine("1. Enter Data");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            LoadWeatherData(weatherMonitor);
                            break;

                        case 2:
                            userInterface = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void LoadWeatherData(WeatherMonitor weatherMonitor)
        {
            Console.WriteLine("Insert Data: ");
            List<string> lines = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                lines.Add(line);
            }
            string rawWeatherInput = string.Join(Environment.NewLine, lines);

            IWeatherInputStrategy inputStrategy = WeatherInputFactory.CreateStrategy(rawWeatherInput);
            
            weatherMonitor.ChangeWeatherData(inputStrategy.ParseWeatherData(rawWeatherInput));

        }        
    }
}