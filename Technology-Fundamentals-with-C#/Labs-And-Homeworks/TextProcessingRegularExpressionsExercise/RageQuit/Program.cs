using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var rageMessage = new StringBuilder();

            string pattern = @"([^0-9]+[0-9]+)";
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string fullMessage = match.ToString().ToUpper();

                string patternText = @"([^0-9]+)";
                var regText = Regex.Match(fullMessage, patternText);
                string text = regText.Value;

                string patternNumber = @"([0-9]+)";
                var regNumber = Regex.Match(fullMessage, patternNumber);
                int number = int.Parse(regNumber.ToString());

                for (int i = 0; i < number; i++)
                {
                    rageMessage.Append(text);
                }
            }

            string unique = new string(rageMessage.ToString().Distinct().ToArray());

            Console.WriteLine($"Unique symbols used: {unique.Length}");
            Console.WriteLine($"{rageMessage.ToString()}");
        }
    }
}
