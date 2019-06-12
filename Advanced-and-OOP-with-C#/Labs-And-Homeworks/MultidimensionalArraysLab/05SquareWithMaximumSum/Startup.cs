using System;
using System.Linq;

namespace _05SquareWithMaximumSum
{
    class Startup
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        colIndex = col;
                        rowIndex = row;
                    }
                }
            }

            // Print the sub-matrix
            Console.WriteLine($"{matrix[rowIndex, colIndex]} " +
                $"{matrix[rowIndex, colIndex + 1]} " + Environment.NewLine +
                $"{matrix[rowIndex + 1, colIndex]} " +
                $"{matrix[rowIndex + 1, colIndex + 1]}" + Environment.NewLine +
                $"{maxSum}");
        }
    }
}
