using System;

namespace _10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int pokePowerOriginal = pokePower * 50 / 100;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int targetsCount = 0;
            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetsCount++;

                if (pokePower == pokePowerOriginal)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetsCount);
        }
    }
}
