using System;
using System.Collections.Generic;
using System.Linq;

namespace _12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isLarger = (name, charsLength) 
                => name.Sum(x => x) >= charsLength;

            Func<List<string>, Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter) => inputNames.FirstOrDefault(x => isLarger(x, length));

            string resultName = nameFilter(names, isLarger);

            Action<string> printName = name => Console.WriteLine(name);

            printName(resultName);
        }
    }
}
