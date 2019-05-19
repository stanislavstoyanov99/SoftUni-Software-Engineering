using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ComparisonOfThreeNumbers());
        }
        static int ComparisonOfThreeNumbers()
        {
            int smallestNumber = int.MaxValue;

            for (int i = 1; i <= 3; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < smallestNumber)
                {
                    smallestNumber = currentNumber;
                }
            }

            return smallestNumber;
        }
    }
}
