using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputSum = double.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();
            double sumToConvert = 0.0;
            // string currency = string.Empty -> string currency = ""

            if (inputCurrency == "USD" && outputCurrency == "BGN")
            {
                sumToConvert = inputSum * 1.79549;
            }
            else if (inputCurrency == "USD" && outputCurrency == "EUR")
            {
                sumToConvert = inputSum * 0.91801;
            }
            else if (inputCurrency == "USD" && outputCurrency == "GBP")
            {
                sumToConvert = inputSum * 0.70854;
            }
            else if (inputCurrency == "EUR" && outputCurrency == "USD")
            {
                sumToConvert = inputSum * 1.08930;
            }
            else if (inputCurrency == "EUR" && outputCurrency == "BGN")
            {
                sumToConvert = inputSum / 1.95583;
            }
            else if (inputCurrency == "EUR" && outputCurrency == "GBP")
            {
                sumToConvert = inputSum * 0.77181;
            }
            else if (inputCurrency == "GBP" && outputCurrency == "USD")
            {
                sumToConvert = inputSum * 1.41134;
            }
            else if (inputCurrency == "GBP" && outputCurrency == "EUR")
            {
                sumToConvert = inputSum * 1.29563;
            }
            else if (inputCurrency == "GBP" && outputCurrency == "BGN")
            {
                sumToConvert = inputSum * 2.53405;
            }
            else if (inputCurrency == "BGN" && outputCurrency == "USD")
            {
                sumToConvert = inputSum * 1.79549;
            }
            else if (inputCurrency == "BGN" && outputCurrency == "EUR")
            {
                sumToConvert = inputSum / 1.95583;
            }
            else if (inputCurrency == "BGN" && outputCurrency == "GBP")
            {
                sumToConvert = inputSum * 2.53405;
            }
            Console.WriteLine($"{sumToConvert:F2} {outputCurrency}");
        }
    }
}
