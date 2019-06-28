using System;

namespace _07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] board = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    board[row, col] = inputRow[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        int currentCount = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredCol < board.GetLength(1) &&
                desiredRow >= 0 && desiredCol >= 0;
        }
    }
}
