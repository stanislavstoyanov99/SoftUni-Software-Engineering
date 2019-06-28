using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstReader = new StreamReader(@"files\words.txt");
            var dictionary = new Dictionary<string, int>();
            var wordsToSearch = new List<string>();

            using (firstReader)
            {
                string firstFileLine = firstReader.ReadLine();
                while (firstFileLine != null)
                {
                    wordsToSearch.Add(firstFileLine);
                    firstFileLine = firstReader.ReadLine();
                }

                using (var secondReader = new StreamReader(@"files\text.txt"))
                {
                    using (var writer = new StreamWriter(@"files\expectedResult.txt"))
                    {
                        string secondFileLine = secondReader.ReadLine().ToLower();
                        int counter = 0;

                        while (secondFileLine != null)
                        {
                            foreach (var word in wordsToSearch)
                            {
                                if (secondFileLine.ToLower().Contains(word))
                                {
                                    if (!dictionary.ContainsKey(word))
                                    {
                                        dictionary.Add(word, ++counter);
                                    }
                                    else
                                    {
                                        dictionary[word] += ++counter;
                                    }

                                    counter = 0;
                                }
                            }

                            secondFileLine = secondReader.ReadLine();
                        }

                        foreach (var word in dictionary.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }

                    string[] dictionaryAsArray = dictionary
                        .Select(word => word.Key + " - " + word.Value)
                        .ToArray();

                    File.WriteAllLines(@"files\actualResult.txt", dictionaryAsArray);
                }
            }
        }
    }
}
