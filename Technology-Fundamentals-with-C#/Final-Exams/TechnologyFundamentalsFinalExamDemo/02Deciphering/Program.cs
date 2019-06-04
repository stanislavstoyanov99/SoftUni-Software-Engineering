using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();
            string pattern = @"^([d-z#|{}]+)$";

            string[] letters = Console.ReadLine().Split();
            bool isTextValid = false;

            if (Regex.IsMatch(encryptedText, pattern))
            {
                isTextValid = true;
            }
            else
            {
                isTextValid = false;
            }

            if (isTextValid)
            {
                var decryptedString = new StringBuilder();

                for (int i = 0; i < encryptedText.Length; i++)
                {
                    char currentCharacter = (char)(encryptedText[i] - 3);
                    decryptedString.Append(currentCharacter);
                }

                string firstSubstring = letters[0];
                string secondSubstring = letters[1];

                decryptedString.Replace(firstSubstring, secondSubstring);

                Console.WriteLine(decryptedString);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
