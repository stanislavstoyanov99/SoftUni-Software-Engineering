using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CountSymbols
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];

                if (!symbols.ContainsKey(currentLetter))
                {
                    symbols.Add(currentLetter, 0);
                }

                symbols[currentLetter]++;
            }

            var filteredSymbols = symbols.OrderBy(x => x.Key);
            foreach (var (letter, count) in filteredSymbols)
            {
                Console.WriteLine($"{letter}: {count} time/s");
            }
        }
    }
}
