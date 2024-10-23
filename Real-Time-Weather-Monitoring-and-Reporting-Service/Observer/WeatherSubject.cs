using Real_Time_Weather_Monitoring_and_Reporting_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Time_Weather_Monitoring_and_Reporting_Service.Observer
{
    public abstract class WeatherSubject
    {
        private List<IWeatherObserver> observers = new List<IWeatherObserver>();

        public void AddObserver(IWeatherObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IWeatherObserver observer)
        {
            observers.Remove(observer);
        }

        public virtual void NotifyObservers(WeatherData weatherData)
        {
            foreach (var observer in observers)
            {
                observer.Activate(weatherData);
            }
        }

    }
}
