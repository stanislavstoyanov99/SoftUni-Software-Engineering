using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        double p1 = 0;
        double p2 = 0;
        double p3 = 0;
        for (int count = 0; count < n; count++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                p1++;
            }
            if (number % 3 == 0)
            {
                p2++;
            }
            if (number % 4 == 0)
            {
                p3++;
            }
        }
        p1 = p1 / n * 100;
        p2 = p2 / n * 100;
        p3 = p3 / n * 100;
        Console.WriteLine($"{p1:F2}%");
        Console.WriteLine($"{p2:F2}%");
        Console.WriteLine($"{p3:F2}%");
    }
}
