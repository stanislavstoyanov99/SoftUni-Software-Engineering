using System;

using Shapes.Exceptions;
using Shapes.Factories;
using Shapes.Models;

namespace Shapes.Core
{
    public class Engine
    {
        private readonly CircleFactory circleFactory;
        private readonly RectangleFactory rectangleFactory;

        public Engine()
        {
            this.circleFactory = new CircleFactory();
            this.rectangleFactory = new RectangleFactory();
        }

        public void Run()
        {
            try
            {
                int radius = int.Parse(Console.ReadLine());
                Circle circle = this.circleFactory.CreateCircle(radius);

                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle rectangle = this.rectangleFactory.CreateRectangle(width, height);

                PrintFigures(circle, rectangle);
            }
            catch (NegativeValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintFigures(Shape circle, Shape rectangle)
        {
            Console.WriteLine(circle.Draw());
            Console.WriteLine($"{circle.CalculateArea():F2}");
            Console.WriteLine($"{circle.CalculatePerimeter():F2}");

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine($"{rectangle.CalculateArea():F2}");
            Console.WriteLine($"{rectangle.CalculatePerimeter():F2}");
        }
    }
}
