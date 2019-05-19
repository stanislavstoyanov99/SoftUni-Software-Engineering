using System;

namespace _02FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                int delimiter = input.IndexOf(' ');
                long firstValue = long.Parse(input.Substring(0, delimiter)); // takes the left number
                long secondValue = long.Parse(input.Substring(delimiter)); // takes the right number

                if (firstValue > secondValue)
                {
                    Console.WriteLine(Sum(firstValue));
                }
                else
                {
                    Console.WriteLine(Sum(secondValue));
                }
            }
        }

        static long Sum(long value)
        {
            long sum = 0;
            while (value != 0)
            {
                sum += value % 10;
                value /= 10;
            }
            return Math.Abs(sum);
        }
    }
}
