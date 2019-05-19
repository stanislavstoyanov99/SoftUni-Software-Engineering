using System;
using System.Linq;

namespace _11LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i].ElementAt(0);
                char lastLetter = input[i].ElementAt(input[i].Length - 1);

                double number = double.Parse(new string(input[i].Skip(1).Take(input[i].Length - 2).ToArray()));

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 64;
                }
                else
                {
                    number += lastLetter - 96;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
