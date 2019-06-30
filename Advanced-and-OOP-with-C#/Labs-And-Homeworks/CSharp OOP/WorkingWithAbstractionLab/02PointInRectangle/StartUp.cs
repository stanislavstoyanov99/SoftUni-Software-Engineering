using System;
using System.Linq;

namespace PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int topLeftX = rectangleCoordinates[0];
            int topLeftY = rectangleCoordinates[1];
            Point topLeftPoint = new Point(topLeftX, topLeftY);

            int bottomRightX = rectangleCoordinates[2];
            int bottomRightY = rectangleCoordinates[3];
            Point bottomRightPoint = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int line = 1; line <= numberOfLines; line++)
            {
                int[] pointCoordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int coordinateX = pointCoordinates[0];
                int coordinateY = pointCoordinates[1];

                Point point = new Point(coordinateX, coordinateY);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
