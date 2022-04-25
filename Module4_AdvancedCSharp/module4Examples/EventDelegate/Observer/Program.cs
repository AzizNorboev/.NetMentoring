using System;
using System.Collections.Generic;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherSubscriber subscriber = new WeatherSubscriber();
            WeatherProvider NDTVProvider = new WeatherProvider("NDTV");
            NDTVProvider.Subscribe(subscriber);
            WeatherProvider TimesProvider = new WeatherProvider("Times");
            TimesProvider.Subscribe(subscriber);
            WeatherProvider HeadLineProvider = new WeatherProvider("HeadLine");
            HeadLineProvider.Subscribe(subscriber);
            subscriber.SetMeasurements(new WeatherData(10, 7, 14));
            HeadLineProvider.Unsubscribe();
            subscriber.SetMeasurements(new WeatherData(28, 26, 14));
            subscriber.SetMeasurements(null);

            Console.Read();
        }
    }
    public class WeatherData
    {
        private float temperature;
        private float humidity;
        private float presssure;

        public WeatherData(float temp, float hum, float press)
        {
            temperature = temp;
            humidity = hum;
            presssure = press;
        }

        public float Temperature
        {
            get { return this.temperature; }
        }
        public float Humidity
        {
            get { return this.humidity; }
        }
        public float Presssure
        {
            get { return this.presssure; }
        }
    }

    public class WeatherProvider : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        private string instName;

        public WeatherProvider(string name)
        {
            this.instName = name;
        }
        public string Name
        {
            get { return this.instName; }
        }
        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }
        void IObserver<WeatherData>.OnCompleted()
        {
            Console.WriteLine("The Provider has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        void IObserver<WeatherData>.OnError(Exception error)
        {
            Console.WriteLine("{0}: The provider cannot be read data.", this.Name);
        }

        void IObserver<WeatherData>.OnNext(WeatherData value)
        {

            Console.WriteLine("{3}: The current Weather is Temperature: {0}, Pressure {1}, Humidty {2}", value.Temperature, value.Presssure, value.Humidity, this.Name);
        }
    }

    public class WeatherSubscriber : IObservable<WeatherData>
    {
        private List<IObserver<WeatherData>> observers;
        public WeatherSubscriber()
        {
            observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> _observers;
            private IObserver<WeatherData> _observer;

            public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void SetMeasurements(WeatherData weather)
        {
            foreach (var observer in observers)
            {
                if (weather == null)
                    observer.OnError(new Exception());
                else
                    observer.OnNext(weather);
            }
        }

    }
}