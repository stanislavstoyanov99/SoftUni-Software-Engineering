using System;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacter(input);
        }

        static void MiddleCharacter(string text)
        {
            if (text.Length % 2 == 0) // the length of string is even
            {
                Console.Write($"{text[text.Length / 2 - 1]}{text[text.Length / 2]}"); // print two middle characters

                Console.WriteLine();
            }
            else // the length of string is odd
            {
                Console.WriteLine($"{text[text.Length / 2]}"); // print the middle character
            }
        }
    }
}
