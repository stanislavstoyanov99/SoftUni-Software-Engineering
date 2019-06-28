using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int givenInteger = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseFunction = numbers =>
            {
                numbers = numbers.Reverse().ToArray();

                return numbers;
            };

            Predicate<int> divisibleNumbers = x => x % givenInteger != 0;

            Action<int[]> printNumbers = numbers =>
            Console.WriteLine(string.Join(" ", numbers));

            inputNumbers = reverseFunction(inputNumbers);
            printNumbers(inputNumbers.Where(x => divisibleNumbers(x)).ToArray());
        }
    }
}
