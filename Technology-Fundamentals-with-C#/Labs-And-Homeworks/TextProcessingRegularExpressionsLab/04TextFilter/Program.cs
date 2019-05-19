using System;

namespace _04TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var wordToRemove in bannedWords)
            {
                // Another way
                //string newString = string.Empty;
                //for (int i = 0; i < wordToRemove.Length; i++)
                //{
                //    newString += "*";
                //}
                string asteriks = new string('*', wordToRemove.Length);

                text = text.Replace(wordToRemove, asteriks);
            }

            Console.WriteLine(text);
        }
    }
}
