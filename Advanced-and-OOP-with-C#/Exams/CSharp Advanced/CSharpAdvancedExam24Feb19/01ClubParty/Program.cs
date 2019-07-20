using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> symbols = new Stack<string>(input);
            Queue<string> halls = new Queue<string>();

            List<int> allGroups = new List<int>();

            while (symbols.Any())
            {
                string currentSymbol = symbols.Pop();
                int currentPeople = 0;

                bool isNumber = int.TryParse(currentSymbol, out currentPeople);

                if (!isNumber)
                {
                    halls.Enqueue(currentSymbol);
                }
                else
                {
                    if (currentPeople + allGroups.Sum() > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                    }

                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    allGroups.Add(currentPeople);
                }
            }
        }
    }
}
