using System;

class Program
{
    static void Main(string[] args)
    {
        double speed = double.Parse(Console.ReadLine());
        string result = string.Empty;

        if (speed > 1000)
        {
            result = "extremely fast";
        }
        else if (speed > 150 && speed <= 1000)
        {
            result = "ultra fast";
        }
        else if (speed > 50 && speed <= 150 )
        {
            result = "fast";
        }
        else if (speed > 10 && speed <= 50)
        {
            result = "average";
        }
        else if (speed <= 10)
        {
            result = "slow";
        }
        Console.WriteLine(result);
    }
}
