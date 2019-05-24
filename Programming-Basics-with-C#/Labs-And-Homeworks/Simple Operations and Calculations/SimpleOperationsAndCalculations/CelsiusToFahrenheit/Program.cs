using System;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var celcius = double.Parse(Console.ReadLine());
            var fahrenheit = (celcius * 1.8) + 32;
            Console.WriteLine(Math.Round(fahrenheit, 2));
        }
    }
}
