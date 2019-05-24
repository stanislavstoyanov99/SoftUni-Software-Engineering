using System;

class Program
{
    static void Main(string[] args)
    {
        double steps = int.Parse(Console.ReadLine());
        double dancers = int.Parse(Console.ReadLine());
        double daysForStudying = int.Parse(Console.ReadLine());

        double stepsPerDay = Math.Ceiling(((steps / daysForStudying) / steps) * 100);
        double stepsPerDancer = stepsPerDay / dancers;

        if (stepsPerDay <= 13)
        {
            Console.WriteLine($"Yes, they will succeed in that goal! {stepsPerDancer:F2}%.");
        }
        else
        {
            Console.WriteLine($"No, They will not succeed in that goal! Required {stepsPerDancer:F2}% steps to be learned per day.");
        }
    }
}
