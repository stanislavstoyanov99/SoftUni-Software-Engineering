using System;
using System.Linq;

namespace _05Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumberOfLetters = int.Parse(Console.ReadLine());

            int numberOfDigits = 0;
            int mainDigit = 0;

            for (int count = 1; count <= totalNumberOfLetters; count++)
            {
                string input = Console.ReadLine();
                numberOfDigits = input.Count(char.IsDigit); // takes the number of digits
                int inputasInteger = int.Parse(input); // parse the input to integer
                mainDigit = inputasInteger % 10;

                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                int letterIndex = offset + numberOfDigits - 1;

                int index = 97 + letterIndex;

                if (inputasInteger != 0)
                {
                    Console.Write((char)index);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
