using System;

class Program
{
    static void Main(string[] args)
    {
        int totalNumber = int.Parse(Console.ReadLine());
        int max = int.MinValue;

        for (int i = 0; i < totalNumber; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine(max);
    }
}
