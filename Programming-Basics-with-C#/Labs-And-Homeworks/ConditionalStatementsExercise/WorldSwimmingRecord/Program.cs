using System;

class Program
{
    static void Main(string[] args)
    {
        double worldRecord = double.Parse(Console.ReadLine());
        double distanceInM = double.Parse(Console.ReadLine());
        double timeInSecondsForOneM = double.Parse(Console.ReadLine());

        double secondsForSwimming = distanceInM * timeInSecondsForOneM;
        double secondsWithWaterResistance = Math.Floor((distanceInM / 15)) * 12.5;
        double totalTime = secondsForSwimming + secondsWithWaterResistance;
        double leftTime = totalTime - worldRecord;

        if (worldRecord <= totalTime)
        {
            Console.WriteLine($"No, he failed! He was {leftTime:F2} seconds slower.");
        }
        else
        {
            Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
        }
    }
}
