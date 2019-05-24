using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeA = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = sizeA * height / 2;
            Console.WriteLine(Math.Round(area, 2));
        }
    }
}
