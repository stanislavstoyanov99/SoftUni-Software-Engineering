using System;
using System.Text;

namespace _06ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var resultInput = new StringBuilder();

            char firstLetter = input[0];
            resultInput.Append(firstLetter);

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                {
                    resultInput.Append(input[i + 1]);
                }
            }

            Console.WriteLine(resultInput);
        }
    }
}
