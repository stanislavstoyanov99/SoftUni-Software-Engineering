using System;
using System.Linq;

namespace _04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> parser = x => double.Parse(x);
            Func<double, double> vatAddition = x => x * 1.20;

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(vatAddition)
                .ToArray();

            foreach (var number in prices)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
