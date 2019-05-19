using System;

namespace _06CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = PrintRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double PrintRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
