using System;

namespace _03LongerLine
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
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double distanceFromCenterFirstPoint = Math.Sqrt(x1 * x1 + y1 * y1);
            double distanceFromCenterSecondPoint = Math.Sqrt(x2 * x2 + y2 * y2);
            double firstLine = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

            double distanceFromCenterThirdPoint = Math.Sqrt(x3 * x3 + y3 * y3);
            double distanceFromCenterFourthPoint = Math.Sqrt(x4 * x4 + y4 * y4);
            double secondLine = Math.Sqrt((x3 - x4) * (x3 - x4) + (y3 - y4) * (y3 - y4));

            if (firstLine > secondLine)
            {
                if (distanceFromCenterSecondPoint < distanceFromCenterFirstPoint)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
            else
            {
                if (distanceFromCenterFourthPoint < distanceFromCenterThirdPoint)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
            }
        }
    }
}
