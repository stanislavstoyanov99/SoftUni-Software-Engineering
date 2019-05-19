using System;

namespace _02CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            CenterPoint();
        }

        private static void CenterPoint()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distanceFromCenterFirstPoint = Math.Sqrt(x1 * x1 + y1 * y1); // c^2 = a^2 + b^2
            double distanceFromCenterSecondPoint = Math.Sqrt(x2 * x2 + y2 * y2);

            if (distanceFromCenterSecondPoint < distanceFromCenterFirstPoint)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
