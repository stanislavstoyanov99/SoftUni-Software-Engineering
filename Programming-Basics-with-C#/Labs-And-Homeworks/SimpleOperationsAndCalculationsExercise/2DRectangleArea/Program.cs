using System;

namespace _2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var height = Math.Abs(x1 - x2);
            var width = Math.Abs(y1 - y2);
            var area = height * width;
            var perimeter = 2 * (height + width);
            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
