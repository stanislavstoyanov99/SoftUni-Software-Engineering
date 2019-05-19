using System;
using System.Diagnostics;
using System.Text;

namespace _07RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatedString(input, count));
        }

        private static string RepeatedString(string input, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(input);
            }

            return sb.ToString();
        }
    }
}
