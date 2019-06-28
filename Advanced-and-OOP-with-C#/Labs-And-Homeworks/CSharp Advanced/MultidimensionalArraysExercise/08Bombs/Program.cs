using System;
using System.Linq;

namespace _08Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            // Fill the matrix
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

            string[] bombCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] bomb = bombCoordinates[i]
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = bomb[0];
                int bombCol = bomb[1];

                if (matrix[bombRow, bombCol] > 0)
                {
                    if (IsInside(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                    }

                    if (IsInside(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            // Print the new matrix
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        // Method, which validates coordinates
        private static bool IsInside(int[,] matrix, int desiredRow, int desiredCol)
        {
            return desiredRow < matrix.GetLength(0) && desiredCol < matrix.GetLength(1) &&
                desiredRow >= 0 && desiredCol >= 0;
        }
    }
}
