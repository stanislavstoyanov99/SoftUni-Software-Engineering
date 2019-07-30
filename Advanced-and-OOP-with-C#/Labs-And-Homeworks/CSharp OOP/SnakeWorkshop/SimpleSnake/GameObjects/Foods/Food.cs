using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Random random;
        private readonly Wall wall;
        private readonly char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;

            this.FoodPoints = foodPoints;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }

        private void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, this.wall.LeftX - 2);
            this.TopY = random.Next(2, this.wall.TopY - 2);

            bool isPointOnSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOnSnake)
            {
                this.LeftX = random.Next(2, this.wall.LeftX - 2);
                this.TopY = random.Next(2, this.wall.TopY - 2);

                isPointOnSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
