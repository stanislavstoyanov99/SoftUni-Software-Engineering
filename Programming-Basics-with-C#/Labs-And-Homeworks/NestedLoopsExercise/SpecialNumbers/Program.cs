using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 1111; i <= 9999; i++)
        {
            string numInString = i.ToString();
            int firstDigit = numInString[0] - '0';
            int secondDigit = numInString[1] - '0';
            int thirdDigit = numInString[2] - '0';
            int fourthDigit = numInString[3] - '0';

            if (firstDigit != 0 && secondDigit != 0 && thirdDigit != 0 && fourthDigit != 0)
            {
                if ((number % firstDigit) == 0 && (number % secondDigit) == 0 && (number % thirdDigit) == 0 && (number % fourthDigit) == 0)
                {
                    Console.Write($"{i} ");
                }
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine();
    }
}
