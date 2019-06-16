using System;
using System.Collections.Generic;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];

                    if (matrix[row, col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            matrix[currentRow, currentCol] = '.';

            char[] directions = Console.ReadLine().ToCharArray();
            var queue = new Queue<char>(directions);

            int newPlayerRow = currentRow;
            int newPlayerCol = currentCol;
            string resultMessage = string.Empty;

            while (queue.Count > 0 )
            {
                switch (queue.Dequeue())
                {
                    case 'U': newPlayerRow -= 1; break;
                    case 'D': newPlayerRow += 1; break;
                    case 'L': newPlayerCol -= 1; break;
                    case 'R': newPlayerCol += 1; break;
                }

                matrix = MultyplyBunnies(matrix, rows, cols);

                if (IsInside(matrix, newPlayerRow, newPlayerCol))
                {
                    currentRow = newPlayerRow;
                    currentCol = newPlayerCol;

                    if (matrix[currentRow, currentCol] == 'B')
                    {
                        resultMessage = $"dead: {currentRow} {currentCol}";
                        break;
                    }
                }
                else
                {
                    resultMessage = $"won: {currentRow} {currentCol}";
                    break;
                }
            }

            // Print lair (matrix)
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(resultMessage);
        }

        private static bool IsInside(char[,] matrix, int desiredRow, int desiredCol)
        {
            return desiredRow < matrix.GetLength(0) && desiredCol < matrix.GetLength(1) &&
                desiredRow >= 0 && desiredCol >= 0;
        }

        private static char[,] MultyplyBunnies(char[,] matrix, int rows, int cols)
        {
            char[,] newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }

                        if (col - 1 >= 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }

                        if (col + 1 < cols)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }

                        if (row + 1 < rows)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
        }
    }
}
