using System;

namespace DivisibleBy3
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 1; number <= 100; number++)
            {
                if (number % 3 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
