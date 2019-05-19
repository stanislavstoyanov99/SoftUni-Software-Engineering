using System;
using System.Diagnostics;
using System.Text;

namespace _04CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var encryptedWord = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char encryptedCharacter = (char)(input[i] + 3);
                encryptedWord.Append(encryptedCharacter);
            }

            Console.WriteLine(encryptedWord);
        }
    }
}
