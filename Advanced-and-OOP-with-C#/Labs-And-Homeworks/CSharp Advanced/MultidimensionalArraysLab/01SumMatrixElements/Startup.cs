using System;
using System.Linq;

namespace _01SumMatrixElements
{
    class Startup
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            int[,] matrix = new int[rows, cols];

            int sumOfAllElements = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentCol = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentCol[col];
                    sumOfAllElements += currentCol[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sumOfAllElements);
        }
    }
}
