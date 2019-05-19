using System;
using System.Linq;

namespace _05SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i]; // the current number of the current index in the array
                if (currentNumber % 2 == 0) // check whether that number is even
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
