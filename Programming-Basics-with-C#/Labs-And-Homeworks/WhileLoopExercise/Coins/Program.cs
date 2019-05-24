using System;

class Program
{
    static void Main(string[] args)
    {
        decimal sum = decimal.Parse(Console.ReadLine());
        int counter = 0;

        while (sum > 0)
        {
            if (sum >= 2)
            {
                sum -= 2;
                counter++;
            }
            else if (sum >= 1)
            {
                sum -= 1;
                counter++;
            }
            else if (sum >= 0.5m)
            {
                sum -= 0.5m;
                counter++;
            }
            else if (sum >= 0.2m)
            {
                sum -= 0.2m;
                counter++;
            }
            else if (sum >= 0.1m)
            {
                sum -= 0.1m;
                counter++;
            }
            else if (sum >= 0.05m)
            {
                sum -= 0.05m;
                counter++;
            }
            else if (sum >= 0.02m)
            {
                sum -= 0.02m;
                counter++;
            }
            else if (sum >= 0.01m)
            {
                counter++;
                break;
            }
        }
        Console.WriteLine($"{counter}");
    }
}
