using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSetSize = sizes[0];
            int secondSetSize = sizes[1];

            for (int i = 0; i < firstSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }

            Console.WriteLine();
        }
    }
}
