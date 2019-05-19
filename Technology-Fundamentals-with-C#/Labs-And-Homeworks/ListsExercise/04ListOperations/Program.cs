using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> tokens = input.Split().ToList();
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd); break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexOfTheNumber = int.Parse(tokens[2]);

                        if (indexOfTheNumber < 0 || indexOfTheNumber > numbers.Count - 1) // check whether the index is valid
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(indexOfTheNumber, numberToInsert); break;
                    case "Remove":
                        int indexToRemove = int.Parse(tokens[1]);
                        Remove(numbers, indexToRemove); break;
                    case "Shift":
                        string typeOfShifting = tokens[1];
                        int countOfNumbersLeftToRight = int.Parse(tokens[2]);
                        Shift(numbers, countOfNumbersLeftToRight, typeOfShifting); break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Remove(List<int> numbers, int index)
        {
            if (index > numbers.Count - 1 || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            numbers.RemoveAt(index);
        }

        private static void Shift(List<int> numbers, int count, string typeOfShifting)
        {
            for (int i = 0; i < count; i++)
            {
                if (typeOfShifting == "left") // shift left
                {
                    numbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                }
                else // shift right
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]); // insert the last element at the first position of the list
                    numbers.RemoveAt(numbers.Count - 1); // remove the last element, because insert changes the indexes of the numbers
                }
            }
        }
    }
}
