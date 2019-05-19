using System;

namespace MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int product = 1;

            if (multiplier > 10)
            {
                product = number * multiplier;
                Console.WriteLine($"{number} X {multiplier} = {product}");
                return;
            }

            for (int i = multiplier; i <= 10; i++)
            {
                product = number * i;
                Console.WriteLine($"{number} X {i} = {product}");
            }
        }
    }
}
