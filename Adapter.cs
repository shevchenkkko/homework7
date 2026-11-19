using System;
using System.Text;

namespace AdapterPattern
{
    interface ITemperatureSensor
    {
        double GetTemperatureCelsius();
    }

    class LegacyFahrenheitSensor
    {
        private readonly double temperatureFahrenheit;

        public LegacyFahrenheitSensor(double temperatureFahrenheit)
        {
            this.temperatureFahrenheit = temperatureFahrenheit;
        }

        public double GetTemperatureFahrenheit()
        {
            return temperatureFahrenheit;
        }
    }

    // Adapter
    class FahrenheitSensorAdapter : ITemperatureSensor
    {
        private readonly LegacyFahrenheitSensor fahrenheitSensor;

        public FahrenheitSensorAdapter(
            LegacyFahrenheitSensor fahrenheitSensor)
        {
            this.fahrenheitSensor = fahrenheitSensor;
        }

        public double GetTemperatureCelsius()
        {
            double fahrenheit =
                fahrenheitSensor.GetTemperatureFahrenheit();

            return (fahrenheit - 32) * 5.0 / 9.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            LegacyFahrenheitSensor legacySensor =
                new LegacyFahrenheitSensor(77);

            ITemperatureSensor sensor =
                new FahrenheitSensorAdapter(legacySensor);

            Console.WriteLine(
                $"Старий датчик: " +
                $"{legacySensor.GetTemperatureFahrenheit():0.##}°F");
            Console.WriteLine(
                $"Температура для програми: " +
                $"{sensor.GetTemperatureCelsius():0.##}°C");
        }
    }
}
