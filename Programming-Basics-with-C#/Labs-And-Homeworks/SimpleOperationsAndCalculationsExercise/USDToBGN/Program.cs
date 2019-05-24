using System;

namespace USDToBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            var dollars = double.Parse(Console.ReadLine());
            var leva = dollars * 1.79549;
            Console.WriteLine(Math.Round(leva, 2));
        }
    }
}
