using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine().Where(c => !char.IsWhiteSpace(c)).ToArray();
            // char[] characters = Console.ReadLine().Where(c => c != ' ').ToArray();
            var counts = new Dictionary<char, int>();

            foreach (char character in characters)
            {
                if (counts.ContainsKey(character))
                {
                    counts[character]++;
                }
                else
                {
                    counts.Add(character, 1);
                }
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
