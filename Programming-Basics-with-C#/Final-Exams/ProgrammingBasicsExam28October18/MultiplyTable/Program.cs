using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        string numberInString = number.ToString();

        int rightDigit = numberInString[2] - '0';
        int middleDigit = numberInString[1] - '0';
        int leftDigit = numberInString[0] - '0';

        int sum = rightDigit * middleDigit * leftDigit;

        for (int j = 1; j <= rightDigit; j++)
        {
            for (int p = 1; p <= middleDigit; p++)
            {
                for (int i = 1; i <= leftDigit; i++)
                {
                    int result = j * p * i;
                    Console.WriteLine($"{j} * {p} * {i} = {result};");
                }
            }
        }
    }
}
