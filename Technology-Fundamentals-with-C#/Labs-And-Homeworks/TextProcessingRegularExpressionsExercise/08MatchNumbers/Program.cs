using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            var matchedNumbers = Regex.Matches(input, pattern);

            var phones = new List<string>();
            foreach (Match number in matchedNumbers)
            {
                phones.Add(number.Value);
            }

            Console.WriteLine(string.Join(" ", phones));
        }
    }
}
