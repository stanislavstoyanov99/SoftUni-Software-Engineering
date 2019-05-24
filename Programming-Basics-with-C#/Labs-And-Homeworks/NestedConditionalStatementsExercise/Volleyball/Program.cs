using System;

class Program
{
    static void Main(string[] args)
    {
        string typeOfYear = Console.ReadLine();
        int numberOfHolidays = int.Parse(Console.ReadLine());
        int numberOfWeekendsInHome = int.Parse(Console.ReadLine());

        double weekendsInSofia = 48 - numberOfWeekendsInHome;
        double numberOfGamesInSofia = weekendsInSofia * 3.0 / 4;
        double numberOfGamesInHome = numberOfWeekendsInHome;
        double numberOfGamesInHolidays = numberOfHolidays * 2.0 / 3;
        double totalGames = numberOfGamesInSofia + numberOfGamesInHome + numberOfGamesInHolidays;
        if (typeOfYear == "leap")
        {
            double additionalGames = totalGames * 0.15;
            totalGames += additionalGames;
            Console.WriteLine($"{Math.Truncate(totalGames)}");
        }
        else if (typeOfYear == "normal")
        {
            Console.WriteLine($"{Math.Truncate(totalGames)}");
        }
    }
}
