using System;
using System.Linq;

namespace _06BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombParameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = bombParameters[0];
            int targetCol = bombParameters[1];
            int radius = bombParameters[2];

            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            // Fill all the cells with zeros
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            // Fill the radius triangle with 1 using Pythagorean Theorem
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            // Move all 1 to the top of the field
            for (int col = 0; col < cols; col++)
            {
                int counter = 0;

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                        matrix[row, col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row, col] = 1;
                }
            }

            // Print the matrix
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
