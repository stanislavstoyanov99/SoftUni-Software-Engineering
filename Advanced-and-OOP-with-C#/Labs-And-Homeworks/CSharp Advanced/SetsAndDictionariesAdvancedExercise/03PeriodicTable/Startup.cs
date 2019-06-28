using System;
using System.Collections.Generic;
using System.Linq;

namespace _03PeriodicTable
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] chemicalElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var element in chemicalElements)
                {
                    elements.Add(element);
                }
            }

            foreach (var element in elements.OrderBy(x => x))
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
