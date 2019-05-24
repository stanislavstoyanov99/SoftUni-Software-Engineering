using System;


class Program
{
    static void Main(string[] args)
    {
        int points = int.Parse(Console.ReadLine());
        double bonusPoints = 0.0;

        if (points > 1000)
        {
            bonusPoints = 0.1 * points;
        }
        else if (points > 100)
        {
            bonusPoints = 0.2 * points;
        }
        else if (points < 100)
        {
            bonusPoints = 5;
        }

        if (points % 2 == 0)
        {
            bonusPoints += 1;
        }
        else if (points % 10 == 5)
        {
            bonusPoints += 2;
        }
        double totalPoints = bonusPoints + points;
        Console.WriteLine(bonusPoints);
        Console.WriteLine(totalPoints);
    }
}
