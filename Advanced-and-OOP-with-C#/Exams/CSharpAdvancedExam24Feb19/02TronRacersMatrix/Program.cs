using System;

namespace _02TronRacers
{
    class Program
    {
        static char[,] field;
        static int firstPlayerRow;
        static int firstPlayerCol;
        static int secondPlayerRow;
        static int secondPlayerCol;

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            field = new char[fieldSize, fieldSize];

            // Fill the matrix and find players positions
            for (int row = 0; row < fieldSize; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = values[col];

                    if (field[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    if (field[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            // Main logic of program
            while (true)
            {
                string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstPlayerDirection = directions[0];
                string secondPlayerDirection = directions[1];

                switch (firstPlayerDirection)
                {
                    case "up":
                        firstPlayerRow--;

                        if (firstPlayerRow < 0)
                        {
                            firstPlayerRow = fieldSize - 1;
                        }

                        break;
                    case "down":
                        firstPlayerRow++;
                        if (firstPlayerRow == fieldSize)
                        {
                            firstPlayerRow = 0;
                        }

                        break;
                    case "right":
                        firstPlayerCol++;
                        if (firstPlayerCol == fieldSize)
                        {
                            firstPlayerCol = 0;
                        }

                        break;
                    case "left":
                        firstPlayerCol--;

                        if (firstPlayerCol < 0)
                        {
                            firstPlayerCol = fieldSize - 1;
                        }

                        break;
                }

                if (field[firstPlayerRow, firstPlayerCol] == 's')
                {
                    field[firstPlayerRow, firstPlayerCol] = 'x';
                    End();
                }
                else
                {
                    field[firstPlayerRow, firstPlayerCol] = 'f';
                }

                switch (secondPlayerDirection)
                {
                    case "up":
                        secondPlayerRow--;
                        if (secondPlayerRow < 0)
                        {
                            secondPlayerRow = fieldSize - 1;
                        }

                        break;
                    case "down":
                        secondPlayerRow++;
                        if (secondPlayerRow == fieldSize)
                        {
                            secondPlayerRow = 0;
                        }

                        break;
                    case "right":
                        secondPlayerCol++;
                        if (secondPlayerCol == fieldSize)
                        {
                            secondPlayerCol = 0;
                        }

                        break;
                    case "left":
                        secondPlayerCol--;
                        if (secondPlayerCol < 0)
                        {
                            secondPlayerCol = fieldSize - 1;
                        }

                        break;
                }

                if (field[secondPlayerRow, secondPlayerCol] == 'f')
                {
                    field[secondPlayerRow, secondPlayerCol] = 'x';
                    End();
                }
                else
                {
                    field[secondPlayerRow, secondPlayerCol] = 's';
                }
            }
        }

        // Finish the program and print the matrix
        private static void End()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }
    }
}
