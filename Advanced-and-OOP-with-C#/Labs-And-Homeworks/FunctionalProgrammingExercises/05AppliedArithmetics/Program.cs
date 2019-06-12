using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> addition = numbers =>
            {
                numbers = numbers.Select(x => x + 1).ToList();

                return numbers;
            };

            Func<List<int>, List<int>> multiply = numbers =>
            {
                numbers = numbers.Select(x => x * 2).ToList();

                return numbers;
            };

            Func<List<int>, List<int>> subtract = numbers =>
            {
                numbers = numbers.Select(x => x - 1).ToList();

                return numbers;
            };

            Action<List<int>> printNumbers = numbers =>
            Console.WriteLine(string.Join(" ", numbers));

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "add")
                {
                    inputNumbers = addition(inputNumbers);
                }
                else if (input == "multiply")
                {
                    inputNumbers = multiply(inputNumbers);
                }
                else if (input == "subtract")
                {
                    inputNumbers = subtract(inputNumbers);
                }
                else if (input == "print")
                {
                    printNumbers(inputNumbers);
                }
            }
        }
    }
}
