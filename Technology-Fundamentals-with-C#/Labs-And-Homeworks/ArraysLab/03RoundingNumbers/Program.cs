using System;

namespace _03RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] numbers = values.Split();
            double[] roundedNumbers = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                roundedNumbers[i] = double.Parse(numbers[i]);
                Console.WriteLine($"{roundedNumbers[i]} => {(int)Math.Round(roundedNumbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
