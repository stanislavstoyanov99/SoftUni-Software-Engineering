namespace SimpleSnake.Core
{
    using System;
    using System.Threading;

    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;

    public class Engine
    {
        private readonly Point[] pointsOfDirection;
        private readonly Snake snake;
        private readonly Wall wall;
        private Direction direction;

        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                this.sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
