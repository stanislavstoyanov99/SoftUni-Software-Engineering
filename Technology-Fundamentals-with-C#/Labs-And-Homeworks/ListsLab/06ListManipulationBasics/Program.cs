using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> tokens = input.Split(" ").ToList();
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        Add(numbers, numberToAdd); break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        Remove(numbers, numberToRemove); break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        RemoveAt(numbers, indexToRemove); break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        Insert(numbers, numberToInsert, indexToInsert); break;
                }
            }

            Console.WriteLine(PrintList(numbers));
        }

        private static string Add(List<int> numbers, int number)
        {
            numbers.Add(number);
            return PrintList(numbers);
        }

        private static string Remove(List<int> numbers, int number)
        {
            numbers.Remove(number);
            return PrintList(numbers);
        }

        private static string RemoveAt(List<int> numbers, int number)
        {
            numbers.RemoveAt(number);
            return PrintList(numbers);
        }

        private static string Insert(List<int> numbers, int number, int index)
        {
            numbers.Insert(index, number);
            return PrintList(numbers);
        }

        private static string PrintList(List<int> numbers)
        {
            return string.Join(" ", numbers);
        }
    }
}
