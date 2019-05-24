using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int digit = 0;
        for (int row = 0; row < number; row++)
        {
            for (int col = 0; col < number; col++)
            {
                digit = row + col + 1;
                if (digit > number)
                {
                    digit = (2 * number) - digit;
                }
                Console.Write($"{digit} ");
            }
            Console.WriteLine();
        }
    }
}
