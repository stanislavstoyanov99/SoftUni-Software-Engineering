using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = x => char.IsUpper(x[0]);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            Action<string[]> printResult = x => Console.WriteLine(string.Join(Environment.NewLine, input));
            printResult(input);
        }
    }
}
