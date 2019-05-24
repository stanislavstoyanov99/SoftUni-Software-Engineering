using System;

class Program
{
    static void Main(string[] args)
    {
        string teamName = Console.ReadLine();
        int numberOfPlayedMatches = int.Parse(Console.ReadLine());

        int numberOfGamesCounter = 0;
        int points = 0;
        int totalScoredGoals = 0;
        int totalReceivedGoals = 0;

        while (numberOfGamesCounter != numberOfPlayedMatches)
        {
            int scoredGoals = int.Parse(Console.ReadLine());
            int receivedGoals = int.Parse(Console.ReadLine());
            totalScoredGoals += scoredGoals;
            totalReceivedGoals += receivedGoals;
            numberOfGamesCounter++;
            if (scoredGoals > receivedGoals)
            {
                points += 3;
            }
            else if (scoredGoals == receivedGoals)
            {
                points += 1;
            }
        }
        int goalDifference = totalScoredGoals - totalReceivedGoals;
        if (totalScoredGoals >= totalReceivedGoals)
        {
            Console.WriteLine($"{teamName} has finished the group phase with {points} points.");
            Console.WriteLine($"Goal difference: {goalDifference}.");
        }
        else
        {
            Console.WriteLine($"{teamName} has been eliminated from the group phase.");
            Console.WriteLine($"Goal difference: {goalDifference}.");
        }
    }
}
