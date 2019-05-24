using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            var area = a * b;
            Console.WriteLine(area);
        }
    }
}
