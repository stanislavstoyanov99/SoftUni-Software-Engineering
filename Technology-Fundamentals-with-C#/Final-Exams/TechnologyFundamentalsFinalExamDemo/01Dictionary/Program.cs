using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();

            var wordsInDictionary = new List<string>();
            var availableWords = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(" | ");

                foreach (var item in tokens)
                {
                    string[] wordsAndDefinitions = item.Split(": ");
                    string word = wordsAndDefinitions[0];

                    if (!wordsInDictionary.Contains(word))
                    {
                        wordsInDictionary.Add(word);
                    }
                    string definition = wordsAndDefinitions[1];

                    if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, new List<string>() { definition });
                    }
                    else
                    {
                        dictionary[word].Add(definition);
                    }
                }

                string[] wordsTokens = Console.ReadLine().Split(" | ");
                foreach (var currentWord in wordsTokens)
                {
                    if (!availableWords.Contains(currentWord))
                    {
                        availableWords.Add(currentWord);
                    }
                }

                string command = Console.ReadLine();
                if (command == "End")
                {
                    foreach (var kvp in dictionary.OrderBy(x => x.Key))
                    {
                        if (availableWords.Contains(kvp.Key))
                        {
                            Console.WriteLine($"{kvp.Key}");
                            Console.WriteLine($" -{string.Join(Environment.NewLine + " -", kvp.Value.OrderByDescending(x => x.Length))}");
                        }
                    }

                    break;
                }
                else if (command == "List")
                {
                    Console.WriteLine(string.Join(" ", wordsInDictionary.OrderBy(x => x)));
                    break;
                }
            }
        }
    }
}
