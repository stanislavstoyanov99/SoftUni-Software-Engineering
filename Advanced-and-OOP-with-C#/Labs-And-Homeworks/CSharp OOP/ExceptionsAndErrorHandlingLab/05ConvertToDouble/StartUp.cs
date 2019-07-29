using System;
using System.Collections.Generic;

namespace _05ConvertToDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> values = new List<string>
            {
                "-1,035.77219", "1AFF", "1e-35",
                "1,635,592,999,999,999,999,999,999", "-17.455",
                "190.34001", "1.29e325"
            };

            double result = 0;

            foreach (var value in values)
            {
                try
                {
                    result = Convert.ToDouble(value);
                    Console.WriteLine($"Converted '{value}' to {result}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to convert '{value}' to a Double.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"'{value}' is outside the range of a Double.");
                }
            }
        }
    }
}
