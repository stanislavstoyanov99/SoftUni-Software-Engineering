using System;
using System.Linq;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int givenNameLenght = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> filterNames = name => name.Length <= givenNameLenght;

            Action<string[]> printNames = names =>
            Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(inputNames.Where(x => filterNames(x)).ToArray());
        }
    }
}
