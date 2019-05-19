using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _09StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            int attackedPlanetsCount = 0;
            int destroyedPlanetsCount = 0;
            int descryptionKey = 0;

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            var decryptedMessage = new StringBuilder();
            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();

                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    if (encryptedMessage[j] == 's' || encryptedMessage[j] == 't'
                        || encryptedMessage[j] == 'a' || encryptedMessage[j] == 'r'
                        || encryptedMessage[j] == 'S' || encryptedMessage[j] == 'T'
                        || encryptedMessage[j] == 'A' || encryptedMessage[j] == 'R')
                    {
                        descryptionKey++;
                    }
                }

                for (int k = 0; k < encryptedMessage.Length; k++)
                {
                    char currentCharacter = (char)(encryptedMessage[k] - descryptionKey);
                    decryptedMessage.Append(currentCharacter);
                }

                string decryptedMessageAsString = decryptedMessage.ToString();

                string pattern = @"(?<planet>[A-Z][a-z]+)(?:[^@\-!:>]*)\:\d+\!(?<attack>[A,D])!(?:[^@\-!:>]*)\-\>\d+";
                var matchedMessage = Regex.Matches(decryptedMessageAsString, pattern);

                foreach (Match item in matchedMessage)
                {
                    string planetname = item.Groups["planet"].Value;
                    string attackType = item.Groups["attack"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanetsCount++;
                        attackedPlanets.Add(planetname);
                    }
                    else
                    {
                        destroyedPlanetsCount++;
                        destroyedPlanets.Add(planetname);
                    }
                }

                decryptedMessage.Clear();
                descryptionKey = 0;
            }

            Console.WriteLine($"Attacked planets: {attackedPlanetsCount}");
            foreach (var item in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanetsCount}");
            foreach (var item in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
