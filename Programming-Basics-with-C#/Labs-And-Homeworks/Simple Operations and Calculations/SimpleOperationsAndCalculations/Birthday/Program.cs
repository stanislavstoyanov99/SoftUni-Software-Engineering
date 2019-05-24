using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            var percentage = double.Parse(Console.ReadLine()) * 0.01;
            var capacity = length * width * height;
            var litres = capacity * 0.001;
            var totalLitres = litres * (1 - percentage);
            Console.WriteLine("{0:F3}", totalLitres);
        }
    }
}
