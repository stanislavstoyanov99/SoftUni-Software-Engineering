using System;
using System.Linq;

namespace _03PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            // Filling matrix
            for (int row = 0; row < matrixSize; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int currentRow = 0;
            int currentCol = 0;
            int sum = 0;

            // Find the sum of primary diagonal
            while (true)
            {
                if (currentRow >= matrixSize || currentCol >= matrixSize)
                {
                    break;
                }

                sum += matrix[currentRow, currentCol];

                currentRow++;
                currentCol++;
            }

            Console.WriteLine(sum);
        }
    }
}
