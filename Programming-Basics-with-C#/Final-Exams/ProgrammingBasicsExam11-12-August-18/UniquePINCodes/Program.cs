using System;

class Program
{
    static void Main(string[] args)
    {
        int firstNumberBoundary = int.Parse(Console.ReadLine());
        int secondNumberBoundary = int.Parse(Console.ReadLine());
        int thirdNumberBoundary = int.Parse(Console.ReadLine());

        bool isFirstNumberEven = true;
        bool isNumberSimple = true;
        bool isThirdNumberEven = true;

        for (int firstDigit = 1; firstDigit <= firstNumberBoundary; firstDigit++)
        {
            for (int secondDigit = 1; secondDigit <= secondNumberBoundary; secondDigit++)
            {
                for (int thirdDigit = 1; thirdDigit <= thirdNumberBoundary; thirdDigit++)
                {
                    if (firstDigit % 2 == 0)
                    {
                        isFirstNumberEven = true;
                    }
                    else
                    {
                        isFirstNumberEven = false;
                    }

                    if ((secondDigit == 2) || (secondDigit == 3) || (secondDigit == 5) || (secondDigit == 7))
                    {
                        isNumberSimple = true;
                    }
                    else
                    {
                        isNumberSimple = false;
                    }

                    if (thirdDigit % 2 == 0)
                    {
                        isThirdNumberEven = true;
                    }
                    else
                    {
                        isThirdNumberEven = false;
                    }

                    if (isFirstNumberEven && isThirdNumberEven && isNumberSimple)
                    {
                        Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit}");
                    }
                }
            }
        }
    }
}
