using System;

namespace _02SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int lastDigit;
            int sum = 0;

            while (number != 0)
            {
                lastDigit = number % 10;
                sum += lastDigit;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
