using System;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());
            int maxPoints = 0;
            int scoredGoals = 0;
            int receivedGoals = 0;
            int difference = 0;
            int counter = 0;

            while (counter < playedMatches)
            {
                scoredGoals = int.Parse(Console.ReadLine());
                receivedGoals = int.Parse(Console.ReadLine());
                difference += scoredGoals - receivedGoals;
                if (scoredGoals > receivedGoals)
                {
                    maxPoints += 3;
                }
                else if (scoredGoals == receivedGoals)
                {
                    maxPoints += 1;
                }
                counter++;
            }
            if (difference >=0)
            {
                Console.WriteLine($"{teamName} has finished the group phase with {maxPoints} points.");
                Console.WriteLine($"Goal difference: {difference}.");
            }
            else
            {
                Console.WriteLine($"{teamName} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {difference}.");
            }
        }
    }
}
