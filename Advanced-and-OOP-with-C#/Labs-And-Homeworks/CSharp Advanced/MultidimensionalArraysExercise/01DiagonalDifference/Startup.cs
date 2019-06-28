using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class Startup
    {
        static int[][] matrix;

        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            matrix = new int[sizeOfMatrix][];

            PopulateMatrix(sizeOfMatrix);

            int result = GetAbsoluteValueOfDiagonals();

            Console.WriteLine(result);

            //int matrixSize = int.Parse(Console.ReadLine());
            //int[,] matrix = new int[matrixSize, matrixSize];

            //for (int row = 0; row < matrixSize; row++)
            //{
            //    int[] values = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .ToArray();

            //    for (int col = 0; col < matrixSize; col++)
            //    {
            //        matrix[row, col] = values[col];
            //    }
            //}

            //int currentRow = 0;
            //int currentCol = 0;
            //int sumPrimaryDiagonal = 0;

            //while (true)
            //{
            //    if (currentRow >= matrixSize || currentCol >= matrixSize)
            //    {
            //        break;
            //    }

            //    sumPrimaryDiagonal += matrix[currentRow, currentCol];
            //    currentRow++;
            //    currentCol++;
            //}

            //currentRow = 0;
            //currentCol = matrixSize - currentRow - 1;
            //int sumAntiDiagonal = 0;

            //while (true)
            //{
            //    if (currentRow >= matrixSize || currentCol >= matrixSize
            //        || currentRow < 0 || currentCol < 0)
            //    {
            //        break;
            //    }

            //    sumAntiDiagonal += matrix[currentRow, currentCol];
            //    currentRow++;
            //    currentCol--;
            //}

            //int difference = Math.Abs(sumPrimaryDiagonal - sumAntiDiagonal);
            //Console.WriteLine(difference);
        }

        static void PopulateMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        static int GetAbsoluteValueOfDiagonals()
        {
            int sumOfPrimaryDiagonal = 0;
            int sumOfAntiDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumOfPrimaryDiagonal += matrix[row][row];
                sumOfAntiDiagonal += matrix[row][matrix.GetLength(0) - row - 1];
            }

            int result = Math.Abs(sumOfPrimaryDiagonal - sumOfAntiDiagonal);

            return result;
        }
    }
}
