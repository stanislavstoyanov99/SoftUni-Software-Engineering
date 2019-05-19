using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" ");
                string command = tokens[0];

                switch (command)
                {
                    case "max":
                        Max(tokens[1], arrayNumbers); break;
                    case "min":
                        Min(tokens[1], arrayNumbers); break;
                    case "first":
                        First(arrayNumbers, int.Parse(tokens[1]), tokens[2]); break;
                    case "last":
                        Last(arrayNumbers, int.Parse(tokens[1]), tokens[2]); break;
                    case "exchange":
                        arrayNumbers = Exchange(arrayNumbers, int.Parse(tokens[1])); break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", arrayNumbers)}]");
        }

        private static int[] Exchange(int[] arrayNumbers, int index)
        {
            if (index >= arrayNumbers.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return arrayNumbers;
            }
            int[] firstSplit = new int[index + 1];
            int[] secondSplit = new int[arrayNumbers.Length - 1 - index];

            for (int i = 0; i < index + 1; i++)
            {
                firstSplit[i] = arrayNumbers[i];
            }

            for (int i = 0; i < arrayNumbers.Length - 1 - index; i++)
            {
                secondSplit[i] = arrayNumbers[i + index + 1];
            }

            int[] resultArray = new int[arrayNumbers.Length];
            for (int i = 0; i < firstSplit.Length; i++)
            {
                arrayNumbers[secondSplit.Length + i] = firstSplit[i];
            }

            for (int i = 0; i < secondSplit.Length; i++)
            {
                arrayNumbers[i] = secondSplit[i];
            }

            string.Join(", ", arrayNumbers);
            return arrayNumbers;
        }

        private static void Max(string typeOfCommand, int[] arrayNumbers)
        {
            int index = 0;
            int maxValue = int.MinValue;
            bool isMaxEvenExists = false;
            bool isMaxOddExists = false;

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (typeOfCommand == "even")
                {
                    if (arrayNumbers[i] % 2 == 0 && arrayNumbers[i] >= maxValue)
                    {
                        index = i;
                        maxValue = arrayNumbers[i];
                        isMaxEvenExists = true;
                    }
                }
                else if (typeOfCommand == "odd")
                {
                    if (arrayNumbers[i] % 2 != 0 && arrayNumbers[i] >= maxValue)
                    {
                        index = i;
                        maxValue = arrayNumbers[i];
                        isMaxOddExists = true;
                    }
                }
            }

            if (isMaxEvenExists || isMaxOddExists)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void Min(string typeOfCommand, int[] arrayNumbers)
        {
            int index = 0;
            int minValue = int.MaxValue;
            bool isMinEvenExists = false;
            bool isMinOddExists = false;

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (typeOfCommand == "even")
                {
                    if (arrayNumbers[i] % 2 == 0 && arrayNumbers[i] <= minValue)
                    {
                        index = i;
                        minValue = arrayNumbers[i];
                        isMinEvenExists = true;
                    }
                }
                else if (typeOfCommand == "odd")
                {
                    if (arrayNumbers[i] % 2 != 0 && arrayNumbers[i] <= minValue)
                    {
                        index = i;
                        minValue = arrayNumbers[i];
                        isMinOddExists = true;
                    }
                }
            }

            if (isMinEvenExists || isMinOddExists)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void First(int[] arrayNumbers, int count, string typeOfCommand)
        {
            if (count > arrayNumbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List <int> resultList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                if (typeOfCommand == "even")
                {
                    resultList = arrayNumbers.Where(x => x % 2 == 0).Take(count).ToList(); // if the current element is even
                }
                else if (typeOfCommand == "odd")
                {
                    resultList = arrayNumbers.Where(x => x % 2 != 0).Take(count).ToList(); // if the current element is odd
                }
            }

            Console.WriteLine($"[{string.Join(", ", resultList)}]");
        }

        private static void Last(int[] arrayNumbers, int count, string typeOfCommand)
        {
            if (count > arrayNumbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List <int> resultList = new List<int>();
            for (int i = 0; i < count; i++)
            {             
                if (typeOfCommand == "even")
                {
                    resultList = arrayNumbers.Where(x => x % 2 == 0).Reverse().Take(count).Reverse().ToList();
                }
                else if (typeOfCommand == "odd")
                {
                    resultList = arrayNumbers.Where(x => x % 2 != 0).Reverse().Take(count).Reverse().ToList();
                }
            }

            Console.WriteLine($"[{string.Join(", ", resultList)}]");
        }
    }
}