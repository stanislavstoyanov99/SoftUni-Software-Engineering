using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long sum = 0;

        public Engine()
        {
            this.matrix = new int[,] { };
        }

        public void Start()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            InitializeMatrix(rows, cols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];
                MoveEvilPosition(evilRow, evilCol);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];
                MovePlayerPositionAndSum(playerRow, playerCol);

                command = Console.ReadLine();
            }

            PrintSum();
        }

        private void PrintSum()
        {
            Console.WriteLine(sum);
        }

        private void MovePlayerPositionAndSum(int playerRow, int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (IsInside(playerRow, playerCol))
                {
                    sum += matrix[playerRow, playerCol];
                }

                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvilPosition(int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInside(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) 
                && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }
    }
}
