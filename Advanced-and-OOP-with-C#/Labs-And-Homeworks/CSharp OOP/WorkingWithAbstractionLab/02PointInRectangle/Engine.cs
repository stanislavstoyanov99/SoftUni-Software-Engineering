using System;
using System.Linq;

namespace PointInRectangle
{
    public class Engine
    {
        private int[] rectangleCoordinates;
        private int[] pointCoordinates;

        public Engine()
        {
            this.rectangleCoordinates = new int[] { };
            this.pointCoordinates = new int[] { };
        }

        public void Start()
        {
            rectangleCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Point topLeftPoint = this.CreateTopLeftPoints();
            Point bottomRightPoint = this.CreateBottomRightPoints();

            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int line = 1; line <= numberOfLines; line++)
            {
                pointCoordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Point point = this.CreatePoint();

                PrintResult(rectangle, point);
            }
        }

        private void PrintResult(Rectangle rectangle, Point point)
        {
            Console.WriteLine(rectangle.Contains(point));
        }

        private Point CreatePoint()
        {
            int coordinateX = pointCoordinates[0];
            int coordinateY = pointCoordinates[1];

            Point point = new Point(coordinateX, coordinateY);

            return point;
        }

        private Point CreateBottomRightPoints()
        {
            int bottomRightX = rectangleCoordinates[2];
            int bottomRightY = rectangleCoordinates[3];

            Point point = new Point(bottomRightX, bottomRightY);

            return point;
        }

        private Point CreateTopLeftPoints()
        {
            int topLeftX = rectangleCoordinates[0];
            int topleftY = rectangleCoordinates[1];

            Point point = new Point(topLeftX, topleftY);

            return point;
        }
    }
}
