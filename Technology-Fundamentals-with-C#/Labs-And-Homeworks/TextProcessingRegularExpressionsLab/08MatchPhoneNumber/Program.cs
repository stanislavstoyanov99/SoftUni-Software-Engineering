using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string regex = @"(?<!\d)[+]359([ -])2\1\d{3}\1\d{4}\b";
            List<string> phones = new List<string>();
            var matchedPhones = Regex.Matches(numbers, regex);

            foreach (Match phone in matchedPhones)
            {
                phones.Add(phone.Value);
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
