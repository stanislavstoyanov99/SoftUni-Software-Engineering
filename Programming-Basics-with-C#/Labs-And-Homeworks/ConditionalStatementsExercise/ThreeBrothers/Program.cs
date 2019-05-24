using System;

class Program
{
    static void Main(string[] args)
    {
        double timeForFirstBrother = double.Parse(Console.ReadLine());
        double timeForSecondBrother = double.Parse(Console.ReadLine());
        double timeForThirdBrother = double.Parse(Console.ReadLine());
        double timeForFishing = double.Parse(Console.ReadLine());

        double timeForBrothers = 1 / (1 / timeForFirstBrother + 1 / timeForSecondBrother + 1 / timeForThirdBrother);
        double timeForBreak = timeForBrothers + (timeForBrothers * 0.15);
        double totalTime = timeForFishing - timeForBreak;
        Console.WriteLine($"Cleaning time: {timeForBreak:F2}");
        if (totalTime >= 0)
        {
            Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(totalTime)} hours.");
        }
        else
        {
            double neededTime = timeForBreak - timeForFishing;
            Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(neededTime)} hours.");
        }
    }
}
