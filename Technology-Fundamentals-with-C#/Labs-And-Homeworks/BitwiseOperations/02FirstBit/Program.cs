using System;

namespace _02FirstBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            // 5 -> 101 -> 0
            // 3 -> 011 -> 1
            number = number >> 1;
            Console.WriteLine(number & 1);
        }
    }
}
