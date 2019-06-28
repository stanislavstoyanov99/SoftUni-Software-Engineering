using System;
using System.Linq;
using System.Collections.Generic;

namespace _05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfNumbers = new Queue<int>();
            foreach (int number in numbers)
            {
                queueOfNumbers.Enqueue(number);
            }

            int[] result = queueOfNumbers.Where(x => x % 2 == 0).ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
