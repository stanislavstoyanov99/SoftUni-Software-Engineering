using System;
using System.Text;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                int sizeOfWord = word.Length;

                for (int i = 0; i < sizeOfWord; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
