using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int count = 1;
        for (int i = 0; i <= number; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (count > number)
                {
                    Console.WriteLine();
                    return;
                }
                Console.Write(count + " ");
                count++;
            }
            Console.WriteLine();
        }
    }
}
