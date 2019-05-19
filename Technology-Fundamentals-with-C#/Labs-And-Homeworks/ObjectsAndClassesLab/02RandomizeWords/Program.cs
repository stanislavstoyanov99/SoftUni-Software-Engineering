using System;
using System.Collections.Generic;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = Console.ReadLine().Split(" ");
            Random rnd = new Random();
            List<string> shuffledWords = new List<string>();

            foreach (var word in inputText)
            {
                int newIndex = rnd.Next(0, shuffledWords.Count + 1);
                shuffledWords.Insert(newIndex, word);
            }

            Console.WriteLine(string.Join(Environment.NewLine, shuffledWords));

            /* Another way to print list elements on new lines
            foreach (var word in shuffledWords)
            {
                Console.WriteLine(word);
            }
            */
        }
    }
}
