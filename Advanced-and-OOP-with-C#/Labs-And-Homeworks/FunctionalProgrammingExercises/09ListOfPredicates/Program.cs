using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> resultNumbers = Enumerable.Range(1, endOfRange).ToList();

            int currentDivider = 0;
            for (int i = 0; i < dividers.Length; i++)
            {
                currentDivider = dividers[i];

                Predicate<int> filterNumbers = number => number % currentDivider == 0;

                resultNumbers = resultNumbers
                    .Where(x => filterNumbers(x))
                    .ToList();
            }

            Action<List<int>> printNumbers = numbers =>
            Console.WriteLine(string.Join(" ", numbers));

            printNumbers(resultNumbers);
        }
    }
}
