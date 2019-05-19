using System;
using System.Collections.Generic;
using System.Linq;

namespace _05RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> positiveNumbers = Console.ReadLine().Split().Select(int.Parse).Where(x => x >= 0).ToList();

            //List<int> positiveNumbers = new List<int>();

            /*foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }*/

            Console.WriteLine(positiveNumbers.Count == 0 ? "empty" : PrintList(positiveNumbers));
        }

        static string PrintList(List<int> positiveNumbers)
        {
            positiveNumbers.Reverse();
            return string.Join(" ", positiveNumbers);
        }
    }
}
