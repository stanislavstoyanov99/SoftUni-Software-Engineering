using System;

namespace _09Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] field = new string[fieldSize, fieldSize];

            string[] moveCommands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int totalCoals = 0;
            int targetRow = 0;
            int targetCol = 0;

            // Fills the matrix with input data, counts coals and finds the start position of the miner - "s"
            for (int row = 0; row < fieldSize; row++)
            {
                string[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = values[col];

                    if (field[row, col] == "c")
                    {
                        totalCoals++;
                    }

                    if (field[row, col] == "s")
                    {
                        targetRow = row;
                        targetCol = col;
                    }
                }
            }

            field[targetRow, targetCol] = "*"; // changes the "s" position with "*"

            bool isGameOver = false;
            bool areCollectedCoals = false;

            for (int i = 0; i < moveCommands.Length; i++)
            {
                string command = moveCommands[i];

                // Moves the miner and checks not to leave the field
                switch (command)
                {
                    case "up":
                        if (targetRow - 1 < fieldSize && targetRow - 1 >= 0)
                        {
                            targetRow -= 1;
                        }

                        break;
                    case "down":
                        if (targetRow + 1 < fieldSize && targetRow + 1 >= 0)
                        {
                            targetRow += 1;
                        }

                        break;
                    case "right":
                        if (targetCol + 1 < fieldSize && targetCol + 1 >= 0)
                        {
                            targetCol += 1;
                        }

                        break;
                    case "left":
                        if (targetCol - 1 < fieldSize && targetCol - 1 >= 0)
                        {
                            targetCol -= 1;
                        }

                        break;
                }

                if (field[targetRow, targetCol] == "c")
                {
                    totalCoals--;
                    field[targetRow, targetCol] = "*";
                }
                else if (field[targetRow, targetCol] == "e")
                {
                    isGameOver = true;
                }

                if (totalCoals == 0)
                {
                    areCollectedCoals = true;
                }

                if (isGameOver)
                {
                    Console.WriteLine($"Game over! ({targetRow}, {targetCol})");
                    break;
                }

                if (areCollectedCoals)
                {
                    Console.WriteLine($"You collected all coals! ({targetRow}, {targetCol})");
                    break;
                }
            }

            if (!(isGameOver == true || areCollectedCoals == true))
            {
                Console.WriteLine($"{totalCoals} coals left. ({targetRow}, {targetCol})");
            }
        }
    }
}
