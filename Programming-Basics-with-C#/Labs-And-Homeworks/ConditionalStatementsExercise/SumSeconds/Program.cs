using System;

class Program
{
    static void Main(string[] args)
    {
        int firstSeconds = int.Parse(Console.ReadLine());
        int secondSeconds = int.Parse(Console.ReadLine());
        int thirdSeconds = int.Parse(Console.ReadLine());

        int totalSeconds = firstSeconds + secondSeconds + thirdSeconds;

        TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
        string timeAsString = time.ToString("m':'ss");
        Console.WriteLine(timeAsString);
    }
}
        //int totalSeconds = firstSeconds + secondSeconds + thirdSeconds;
        //int minutes = totalSeconds / 60;
        //int seconds = totalSeconds % 60;
        //string format = $"{minutes}:{seconds}";
        //DateTime totalTime = DateTime.ParseExact(format, CultureInfo.InvariantCulture);
        //Console.WriteLine(totalTime);

        //if (totalTime > 0 && totalTime <= 59)
        //{
        //    minutes = 0;
        //    Console.WriteLine($"{minutes}:{seconds}");
        //}
        //else if (minutes > 60 && minutes <= 119)
        //{
        //    minutes = 1;
        //    Console.WriteLine($"{minutes}:{seconds - 60}");
        //}
        //else if (minutes > 120 && minutes <= 179)
        //{
        //    minutes = 2;
        //    Console.WriteLine($"{minutes}:{seconds - 120}");
        //}
        //else if (seconds < 10)
        //{
        //    Console.WriteLine($"0:{seconds}");
        //}
    }
}
