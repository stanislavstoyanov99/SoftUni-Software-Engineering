using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] userNames = Console.ReadLine().Split(", ");
            foreach (var word in userNames)
            {
                bool isValidUsername = false;

                if (word.Length >= 3 && word.Length <= 16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currentCharacter = word[j];

                        if (char.IsLetterOrDigit(currentCharacter)
                            || currentCharacter == '-' || currentCharacter == '_')
                        {
                            isValidUsername = true;
                        }
                        else
                        {
                            isValidUsername = false;
                            break;
                        }
                    }
                }

                if (isValidUsername)
                {
                    Console.WriteLine(word);
                }
            }
            */

            string[] usernames = Console.ReadLine().Split(", ")
                .Where(x => x.Length >= 3 && x.Length <= 16)
                .ToArray();

            string pattern = @"^[\w-]{3,16}$";
            var regex = new Regex(pattern);

            foreach (var word in usernames)
            {
                if (regex.IsMatch(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
