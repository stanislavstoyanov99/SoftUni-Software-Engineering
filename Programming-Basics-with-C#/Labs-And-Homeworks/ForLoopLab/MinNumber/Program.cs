using System;

class Program
{
    static void Main(string[] args)
    {
        int totalNumber = int.Parse(Console.ReadLine());
        int min = int.MaxValue;

        for (int i = 0; i < totalNumber; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < min)
            {
                min = number;
            }
        }
        Console.WriteLine(min);
    }
}
