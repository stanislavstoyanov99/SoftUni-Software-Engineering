using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> originalList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> copiedList = new List<string>(originalList);
            List<string> filteredList = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = input.Split(";");

                string command = commandArgs[0];
                string filterType = commandArgs[1];
                string filterParameter = commandArgs[2];

                Predicate<string> startsWith = name => name.StartsWith(filterParameter);
                Predicate<string> endsWith = name => name.EndsWith(filterParameter);

                Func<string, int, bool> length = (x, y) => x.Length == y;
                Func<string, string, bool> contains = (x, y) => x.Contains(y);

                if (filterType == "Starts with")
                {
                    filteredList = originalList
                        .Where(x => startsWith(x))
                        .ToList();
                }
                else if (filterType == "Ends with")
                {
                    filteredList = originalList
                        .Where(x => endsWith(x))
                        .ToList();
                }
                else if (filterType == "Length")
                {
                    filteredList = originalList
                        .Where(x => length(x, int.Parse(filterParameter)))
                        .ToList();
                }
                else if (filterType == "Contains")
                {
                    filteredList = originalList
                        .Where(x => contains(x, filterParameter))
                        .ToList();
                }

                switch (command)
                {
                    case "Add filter":
                        copiedList.RemoveAll(x => filteredList.Contains(x));
                        break;
                    case "Remove filter":
                        copiedList.AddRange(filteredList);
                        copiedList = copiedList.Distinct().ToList();
                        break;
                }
            }

            Action<List<string>> printNames = names =>
            Console.WriteLine(string.Join(" ", names));

            originalList.RemoveAll(x => !copiedList.Contains(x));

            printNames(originalList);
        }
    }
}
