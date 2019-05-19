using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var resultList = new List<int>();

            int sizeOfResultList = Math.Max(firstNumbers.Count, secondNumbers.Count);
            for (int i = 0; i < sizeOfResultList; i++)
            {
                if (i < firstNumbers.Count)
                {
                    resultList.Add(firstNumbers[i]);
                }

                if (i < secondNumbers.Count)
                {
                    resultList.Add(secondNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
