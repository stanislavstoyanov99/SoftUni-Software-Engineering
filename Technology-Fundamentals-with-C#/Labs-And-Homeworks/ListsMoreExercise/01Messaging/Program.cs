using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            List<string> letters = Console.ReadLine().Select(x => x.ToString()).ToList();   // make each letter from the message ToString

            List<string> finalResult = new List<string>();

            for (int i = 0; i < numbers.Count; i++)   // loop all the numbers
            {
                int sumOfDigits = 0;

                foreach (var symbol in numbers[i]) // sum each digit of the current number (9992 -> 29)
                {
                    int digit = symbol - '0';
                    sumOfDigits += digit;
                }

                if (sumOfDigits > letters.Count) // check whether the sum is < of the letters size list (sum == index of the letter)
                {
                    sumOfDigits = sumOfDigits % letters.Count;
                }

                finalResult.Add(letters[sumOfDigits]); // add the current letter to the list finalResult
                letters.RemoveAt(sumOfDigits); // remove the current letter from the list letters
            }

            Console.WriteLine(string.Join("", finalResult));
        }
    }
}
