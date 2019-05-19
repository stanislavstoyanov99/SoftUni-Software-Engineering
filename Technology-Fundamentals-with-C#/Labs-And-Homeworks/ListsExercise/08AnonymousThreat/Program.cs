using System;
using System.Collections.Generic;
using System.Linq;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine().Split().ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "3:1")
            {
                List<string> tokens = input.Split().ToList();
                string command = tokens[0];

                int startIndex = int.Parse(tokens[1]);
                int endIndex = int.Parse(tokens[2]);
                string concatWord = string.Empty;

                // check whether the index is valid (inside the list)
                if (endIndex > strings.Count - 1 || endIndex < 0)
                {
                    endIndex = strings.Count - 1;
                }

                if (startIndex > strings.Count || startIndex < 0)
                {
                    startIndex = 0;
                }

                if (command == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatWord += strings[i];
                    }

                    strings.RemoveRange(startIndex, endIndex - startIndex + 1); // remove the elements from startIndex to count number(second parameter)
                    strings.Insert(startIndex, concatWord); // insert the concatWord at the startIndex
                }
                else if (command == "divide")
                {
                    List<string> dividedElements = new List<string>();

                    int partitions = int.Parse(tokens[2]);
                    string divideWord = strings[startIndex]; // take the word that will be divided
                    strings.RemoveAt(startIndex); // remove the word from the list

                    int parts = divideWord.Length / partitions; // takes the length of the substring part
                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedElements.Add(divideWord.Substring(i * parts)); // Add the last substring part to the dividedElements 
                        }
                        else
                        {
                            dividedElements.Add(divideWord.Substring(i * parts, parts)); // substrings from index[i * parts] to the count(parts)
                        }
                    }

                    strings.InsertRange(startIndex, dividedElements); // insert the dividedElements list into the strings list
                }
            }

            Console.WriteLine(string.Join(" ", strings));
        }
    }
}
