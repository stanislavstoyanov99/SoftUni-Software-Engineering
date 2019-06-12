using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            string command = Console.ReadLine();
                
            List<int> numbers = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isOddNumber = x => x % 2 != 0;
            Predicate<int> isEvenNumber = x => x % 2 == 0;

            Action<List<int>> printNumbers = oddOrEvenNumbers =>
            Console.WriteLine(string.Join(" ", oddOrEvenNumbers));

            if (command == "odd")
            {
                printNumbers(numbers.Where(x => isOddNumber(x)).ToList());
            }
            else
            {
                printNumbers(numbers.Where(x => isEvenNumber(x)).ToList());
            }
        }
    }
}
