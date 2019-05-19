using System;

namespace _03pThBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int positionToMoveBit = int.Parse(Console.ReadLine());

            number = number >> positionToMoveBit;
            Console.WriteLine(number & 1);
        }
    }
}
