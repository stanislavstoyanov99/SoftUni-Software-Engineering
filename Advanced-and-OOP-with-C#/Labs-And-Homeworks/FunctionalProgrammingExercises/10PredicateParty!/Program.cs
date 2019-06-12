using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> additionalList = new List<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string criteria = tokens[1];
                int givenLegth = 0;
                string givenString = string.Empty;

                bool isString = int.TryParse(tokens[2], out givenLegth);

                if (!isString)
                {
                    givenString = tokens[2];
                }

                Predicate<string> startsWith = name => name.StartsWith(givenString);
                Predicate<string> endsWith = name => name.EndsWith(givenString);
                Predicate<string> nameLength = name => name.Length == givenLegth;

                if (command == "Double" && criteria == "Length")
                {
                    additionalList = people.Where(x => nameLength(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Double" && criteria == "StartsWith")
                {
                    additionalList = people.Where(x => startsWith(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Double" && criteria == "EndsWith")
                {
                    additionalList = people.Where(x => endsWith(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Remove" && criteria == "Length")
                {
                    people.RemoveAll(x => nameLength(x));
                }
                else if (command == "Remove" && criteria == "StartsWith")
                {
                    people.RemoveAll(x => startsWith(x));
                }
                else if (command == "Remove" && criteria == "EndsWith")
                {
                    people.RemoveAll(x => endsWith(x));
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Action<List<string>> printNames = names =>
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");

                printNames(people);
            }
        }

        private static List<string> CopyList(List<string> additionalList, List<string> originalList)
        {
            originalList.InsertRange(0, additionalList);

            return originalList;
        }
    }
}
