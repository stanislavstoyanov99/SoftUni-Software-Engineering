using System;

namespace _04SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            // The matrix is square
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            int foundRow = 0;
            int foundCol = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (symbol == matrix[row, col])
                    {
                        foundRow = row;
                        foundCol = col;
                        isFound = true;
                        break;
                    }
                    else
                    {
                        isFound = false;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"({foundRow}, {foundCol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
