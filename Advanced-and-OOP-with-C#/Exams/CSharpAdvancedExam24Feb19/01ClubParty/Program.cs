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

            List<string> halls = new List<string>();
            List<int> people = new List<int>();

            while (symbols.Any())
            {
                string currentSymbol = symbols.Pop();
                int currentPeople = 0;

                bool isNumber = int.TryParse(currentSymbol, out currentPeople);

                if (isNumber)
                {
                    if (halls.Count != 0)
                    {
                        if (currentPeople + people.Sum() <= maxCapacity)
                        {
                            people.Add(currentPeople);
                        }
                        else
                        {
                            Console.WriteLine($"{halls[0]} -> {string.Join(", ", people)}");
                            halls.RemoveAt(0);
                            people.Clear();

                            if (halls.Count != 0)
                            {
                                people.Add(currentPeople);
                            }
                        }
                    }
                }
                else
                {
                    halls.Add(currentSymbol);
                }
            }
        }
    }
}
