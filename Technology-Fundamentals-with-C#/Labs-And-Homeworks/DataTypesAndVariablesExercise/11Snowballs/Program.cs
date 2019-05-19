using System;
using System.Numerics;

namespace _11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowBalls = int.Parse(Console.ReadLine());
            BigInteger snowballMaxValue = 0;

            int snowballMaxShow = 0;
            int snowballMaxTime = 0;
            int snowballMaxQuality = 0;

            for (int i = 1; i <= numberOfSnowBalls; i++)
            {
                int snowballShow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballShow / snowballTime, snowballQuality);
                if (snowballValue > snowballMaxValue)
                {
                    snowballMaxValue = snowballValue;
                    snowballMaxShow = snowballShow;
                    snowballMaxTime = snowballTime;
                    snowballMaxQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{snowballMaxShow} : {snowballMaxTime} = {snowballMaxValue} ({snowballMaxQuality})");
        }
    }
}
