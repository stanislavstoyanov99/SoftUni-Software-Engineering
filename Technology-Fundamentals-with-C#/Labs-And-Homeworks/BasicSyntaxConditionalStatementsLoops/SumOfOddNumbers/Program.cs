using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumbers = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 1;

            for (int i = 1; i <= totalNumbers; i++)
            {
                Console.WriteLine("{0}", number);
                sum += number;
                number += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
