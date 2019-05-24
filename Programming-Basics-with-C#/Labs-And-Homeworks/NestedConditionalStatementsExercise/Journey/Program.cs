using System;

class Program
{
    static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine();

        string destination = string.Empty;
        string typeOfHoliday = string.Empty;

        double result = 0;

        if (budget <= 100)
        {
            destination = "Bulgaria";
            switch (season)
            {
                case "winter":
                    result = budget * 0.7;
                    typeOfHoliday = "Hotel";
                    break;
                case "summer":
                    result = budget * 0.3;
                    typeOfHoliday = "Camp";
                    break;
            }
        }
        else if (budget <= 1000 && budget > 100)
        {
            destination = "Balkans";
            switch (season)
            {
                case "winter":
                    result = budget * 0.8;
                    typeOfHoliday = "Hotel";
                    break;
                case "summer":
                    result = budget * 0.4;
                    typeOfHoliday = "Camp";
                    break;
            }
        }
        else if (budget > 1000)
        {
            destination = "Europe";
            result = budget * 0.9;
            typeOfHoliday = "Hotel";
        }
        Console.WriteLine($"Somewhere in {destination}");
        Console.WriteLine($"{typeOfHoliday} - {result:F2}");
    }
}
