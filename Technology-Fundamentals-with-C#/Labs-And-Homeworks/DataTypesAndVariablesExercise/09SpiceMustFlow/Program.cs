using System;

namespace _09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingSpices = int.Parse(Console.ReadLine());

            int daysCount = 0;
            int totalSpices = 0;

            while (startingSpices >= 100)
            {
                daysCount++;
                int currentSpices = startingSpices - 26;
                totalSpices += currentSpices;
                startingSpices -= 10;

                if (startingSpices < 100)
                {
                    totalSpices -= 26;
                    break;
                }
            }

            Console.WriteLine(daysCount);
            Console.WriteLine(totalSpices);
        }
    }
}
