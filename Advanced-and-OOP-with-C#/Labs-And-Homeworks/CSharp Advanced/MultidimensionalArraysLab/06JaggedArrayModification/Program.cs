using System;
using System.Linq;

namespace _06JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = numbers;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                int rowNumber = int.Parse(tokens[1]);
                int colNumber = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                // Validation in order not to make exception
                if (rowNumber < 0 
                    || rowNumber >= rows 
                    || colNumber < 0 
                    || colNumber >= jaggedArray[rowNumber].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                // Fill the jagged array with the new values
                if (command == "Add")
                {
                    jaggedArray[rowNumber][colNumber] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[rowNumber][colNumber] -= value;
                }
            }

            // Print the jagged array
            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
