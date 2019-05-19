using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            bool isChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> tokens = input.Split(" ").ToList();
                string command = tokens[0];

                switch (command)
                {
                    case "Contains":
                        int numberToCheck = int.Parse(tokens[1]);
                        Contains(numbers, numberToCheck); break;
                    case "PrintEven":
                        PrintEven(numbers); break;
                    case "PrintOdd":
                        PrintOdd(numbers); break;
                    case "GetSum":
                        GetSum(numbers); break;
                    case "Filter":
                        string condition = tokens[1];
                        int numberToStartFiltering = int.Parse(tokens[2]);
                        Filter(numbers, condition, numberToStartFiltering); break;
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        Add(numbers, numberToAdd);
                        isChanged = true; break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        Remove(numbers, numberToRemove);
                        isChanged = true; break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        RemoveAt(numbers, indexToRemove);
                        isChanged = true; break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        Insert(numbers, numberToInsert, indexToInsert);
                        isChanged = true; break;
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void Contains(List<int> numbers, int number)
        {
            if (numbers.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintEven(List<int> numbers)
        {
            Console.WriteLine(PrintList(numbers.Where(x => x % 2 == 0).ToList()));
        }

        private static void PrintOdd(List<int> numbers)
        {
            Console.WriteLine(PrintList(numbers.Where(x => x % 2 != 0).ToList()));
        }

        private static void GetSum(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        private static void Filter(List<int> numbers, string condition, int number)
        {
            if (condition == ">")
            {
                Console.WriteLine(PrintList(numbers.Where(x => x > number).ToList()));
            }
            else if (condition == ">=")
            {
                Console.WriteLine(PrintList(numbers.Where(x => x >= number).ToList()));
            }
            else if (condition == "<")
            {
                Console.WriteLine(PrintList(numbers.Where(x => x < number).ToList()));
            }
            else if (condition == "<=")
            {
                Console.WriteLine(PrintList(numbers.Where(x => x <= number).ToList()));
            }
        }

        private static void Add(List<int> numbers, int number)
        {
            numbers.Add(number);
        }

        private static void Remove(List<int> numbers, int number)
        {
            numbers.Remove(number);
        }

        private static void RemoveAt(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }

        private static void Insert(List<int> numbers, int number, int index)
        {
            numbers.Insert(index, number);
        }

        private static string PrintList(List<int> numbers)
        {
            return string.Join(" ", numbers);
        }
    }
}
