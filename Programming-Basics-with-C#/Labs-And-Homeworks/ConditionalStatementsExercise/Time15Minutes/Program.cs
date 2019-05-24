using System;

class Program
{
    static void Main(string[] args)
    {
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        double totalMinutes = hours * 60 + minutes;

        TimeSpan time = TimeSpan.FromMinutes(totalMinutes + 15);
        string timeAsString = time.ToString("H':'mm");
        Console.WriteLine(timeAsString);
    }
}

