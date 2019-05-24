using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        string numberInString = number.ToString();
        for (int i = 0; i < numberInString.Length; i++)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit == 0)
                {
                    Console.WriteLine("ZERO");
                }
                else
                {
                    for (int p = 0; p < digit; p++)
                    {
                        Console.Write((char)(digit + 33));
                    }
                    Console.WriteLine();
                }
                number /= 10;
            }
        }
    }
}
