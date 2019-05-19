using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int totalLiters = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());
                totalLiters += quantityOfWater;

                if (totalLiters > 255)
                {
                    totalLiters -= quantityOfWater;
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(totalLiters);
        }
    }
}
