using System;
using System.Collections.Generic;
using System.Linq;

namespace _04MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int biggerCount = Math.Max(firstList.Count, secondList.Count);
            int firstConstrain = 0;
            int secondConstrain = 0;

            List<int> biggerList = new List<int>();
            if (biggerCount == firstList.Count)
            {
                biggerList = firstList;
                firstConstrain = firstList.Count - 1;
                secondConstrain = firstList.Count - 2;
            }
            else
            {
                biggerList = secondList;
                firstConstrain = 0;
                secondConstrain = 1;
            }
             
            int minValue = Math.Min(biggerList[firstConstrain], biggerList[secondConstrain]);
            int maxValue = Math.Max(biggerList[firstConstrain], biggerList[secondConstrain]);

            List<int> mixedNumbers = new List<int>();

            mixedNumbers.AddRange(firstList.Where(number => (number > minValue && number < maxValue)).ToList());
            mixedNumbers.AddRange(secondList.Where(number => (number > minValue && number < maxValue)).ToList());

            mixedNumbers.Sort();
            Console.WriteLine(string.Join(" ", mixedNumbers));
        }
    }
}
