using System;

namespace GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());

            double totalMinutes = 0.0;
            double averageMinutes = 0.0;
            int numberOfPenaltiesMatches = 0;
            int numberOfAdditionalTimeMatches = 0;

            for (int i = 1; i <= playedMatches; i++)
            {
                int durationOfMatch = int.Parse(Console.ReadLine());
                totalMinutes += durationOfMatch;
                averageMinutes = totalMinutes / playedMatches;
                if (durationOfMatch > 120)
                {
                    numberOfPenaltiesMatches++;
                }
                else if (durationOfMatch > 90 && durationOfMatch <= 120)
                {
                    numberOfAdditionalTimeMatches++;
                }
            }
            Console.WriteLine($"{teamName} has played {totalMinutes} minutes. Average minutes per game: {averageMinutes:F2}");
            Console.WriteLine($"Games with penalties: {numberOfPenaltiesMatches}");
            Console.WriteLine($"Games with additional time: {numberOfAdditionalTimeMatches}");
        }
    }
}
