using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        for (int count = number; count >= 1; count--)
        {
            Console.WriteLine(count);
        }
    }
}
